using System.Diagnostics;
using System.Text;

using PatchSentry.Secpol.Policies;
using PatchSentry.Utilities;

namespace PatchSentry.Secpol;

public partial class SecpolContainer {
    static readonly Lazy<string> PartialConfigPath = new(() => Path.Join(Program.State.LocalFiles, "secpol.inf"));

    static readonly Lazy<string> SecurityDBPath = new(() => Path.Join(Program.State.LocalFiles, "secpol.db"));

    public Dictionary<string, SecpolSection> Sections = new();

    void Deserialize(IEnumerable<string> lines) {
        var rawSections = new Dictionary<string, Dictionary<string, string>>();
        string? sectionName = null;

        // Convert to primitive cache
        foreach (var line in lines) {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // New Section
            if (line.StartsWith('[') && line.EndsWith(']')) {
                sectionName = line[1..^1];
                continue;
            }
            Except.Assert(sectionName, () => new("No section"));

            // Parse assignment
            var assignment = line.Split('=').Select(x => x.Trim()).ToList();
            Except.Assert(assignment.Count > 0, () => new($"Invalid assignment: {line}"));

            // Separate key and value
            var assignKey = assignment[0]; assignment.RemoveAt(0);
            var assignValue = string.Join('=', assignment);

            // Add to cache
            if (string.IsNullOrEmpty(assignValue)) {
                // "key=", infer default
                rawSections[sectionName!].Remove(assignKey);
            }
            else {
                // "key=value"
                var section = rawSections.TryGetValue(sectionName!, out var value) ? value : rawSections[sectionName!] = new();
                section[assignKey] = assignValue;
            }
        }

        // Convert to section/policy
        /*foreach (var (rawSectionName, rawPolicies) in rawSections) {
            var type = GetTypeFromSection(rawSectionName);
            var section = new SecpolSection {
                Name = rawSectionName,
                Policies = new()
            };

            foreach (var (key, value) in rawPolicies) {
                var policy = new SecpolBase { Name = key, RawValue = value };
                section.Policies.Add(ConvertPolicy(policy, type));
            }

            Sections[rawSectionName] = section;
        }*/
        throw new NotImplementedException();
    }

    public string Serialize() {
        var builder = new StringBuilder();

        foreach (var (sectionName, section) in Sections) {
            builder.Append($"[{sectionName}]\n");
            foreach (var policy in section.Policies)
                builder.Append($"{policy.Name}={policy.RawValue}\n");
        }

        return builder.ToString();
    }

    public async Task ImportAsync() {
        if (File.Exists(PartialConfigPath.Value))
            File.Delete(PartialConfigPath.Value);

        // Dump security policy to a cache file
        var seceditProc = Except.Assert(Process.Start(new ProcessStartInfo("secedit") {
            Arguments = $"/export /cfg {PartialConfigPath.Value}",
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true
        }), () => new("Failed to dump security policy: Process not created"));

        // Wait for it to finish
        await seceditProc.WaitForExitAsync();
        Except.Assert(seceditProc.ExitCode == 0, () => new($"Failed to dump security policy: {seceditProc.StandardOutput.ReadToEnd()}"));

        // Read the file
        var secpolContents = await File.ReadAllLinesAsync(PartialConfigPath.Value);
        Deserialize(secpolContents);
    }

    public async Task ExportAsync() {
        // Write the file
        await File.WriteAllBytesAsync(PartialConfigPath.Value, Encoding.Unicode.GetBytes(Serialize()));

        // Create security policy database from cache file
        var seceditProc = Except.Assert(Process.Start(new ProcessStartInfo("secedit") {
            Arguments = $"/import /db {SecurityDBPath.Value} /cfg {PartialConfigPath.Value}",
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true
        }), () => new("Failed to export security policy database: Process not created"));

        // Wait for it to finish
        await seceditProc.WaitForExitAsync();
        Except.Assert(seceditProc.ExitCode == 0, () => new($"Failed to export security policy database: {seceditProc.StandardOutput.ReadToEnd()}"));

        // Apply the database
        seceditProc = Except.Assert(Process.Start(new ProcessStartInfo("secedit") {
            Arguments = $"/configure /db {SecurityDBPath.Value}",
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true
        }), () => new("Failed to apply security policy database: Process not created"));

        // Wait for it to finish
        await seceditProc.WaitForExitAsync();
        Except.Assert(seceditProc.ExitCode == 0, () => new($"Failed to apply security policy database: {seceditProc.StandardOutput.ReadToEnd()}"));
    }
}
