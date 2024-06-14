using System.Globalization;
using System.Text.RegularExpressions;

using PatchSentry.Utilities;

namespace PatchSentry.Secpol.Policies;

public enum SecpolRegType {
    None,
    String = 1,
    DoubleWord = 4,
    MultiString = 7,
}

public class SecpolRegistry : SecpolBase {
    public readonly SecpolRegType ValueType;
    public readonly string RegValue;

    public SecpolRegistry(SecpolBase baseClass) {
        var failFactory = () => 
            new InvalidOperationException($"Invalid type conversion to {nameof(SecpolRegistry)}");

        // Initial fields
        Name = Except.Assert(baseClass.Name, failFactory);
        RawValue = baseClass.RawValue;

        // Ensure 'Value' is not null
        Except.Assert(RawValue, failFactory);

        // Parse into type and value
        var split = RawValue!.Split(",").ToList();
        Except.Assert(split.Count > 0, () => new InvalidOperationException($"Invalid registry value: {RawValue}"));

        var typeNumber = split[0]; split.RemoveAt(0);
        Except.Assert(Enum.TryParse(typeNumber, out ValueType), () =>
            new InvalidOperationException($"Invalid registry type: {typeNumber}"));

        RegValue = string.Join(",", split.Select(x => x.Trim()));
    }

    public string GetString() {
        Except.Assert(RegValue, () => new InvalidOperationException("Cannot get string from null registry value"));
        Except.Assert(ValueType == SecpolRegType.String, () =>
            new InvalidOperationException($"Cannot get string from registry value of type {ValueType}"));
        Except.Assert(RegValue.StartsWith('"') && RegValue.EndsWith('"'), () =>
            new InvalidOperationException($"Invalid string registry value: {RegValue}"));

        return RegValue[1..^1];
    }

    public uint GetDoubleWord() {
        Except.Assert(RegValue, () => new InvalidOperationException("Cannot get double word from null registry value"));
        Except.Assert(ValueType == SecpolRegType.DoubleWord, () =>
            new InvalidOperationException($"Cannot get double word from registry value of type {ValueType}"));
        Except.Assert(uint.TryParse(RegValue, NumberStyles.Number, CultureInfo.InvariantCulture, out var result), () =>
            new InvalidOperationException($"Invalid double word registry value: {RegValue}"));
        return result;
    }

    public List<string> GetMultiString() {
        Except.Assert(RegValue, () => new InvalidOperationException("Cannot get multi string from null registry value"));
        Except.Assert(ValueType == SecpolRegType.MultiString, () =>
            new InvalidOperationException($"Cannot get multi string from registry value of type {ValueType}"));
        
        var strings = new List<string>();
        foreach (var escapedStr in Regex.Split(RegValue!, @"(?!""),(?!"")")) {
            var str = escapedStr.Replace("\",\"", ",").Replace("\"\"", "\"");
            strings.Add(str);
        }

        return strings;
    }

    public override T Get<T>() {
        var tType = typeof(T);

        if (tType == typeof(string))
            return (T)(object)GetString();

        if (tType == typeof(uint))
            return (T)(object)GetDoubleWord();

        if (tType == typeof(List<string>))
            return (T)(object)GetMultiString();

        throw new InvalidOperationException($"Cannot get value of type {tType} from registry value of type {ValueType}");
    }

    public override string ToString() {
        var typeName = Enum.GetName(typeof(SecpolRegType), ValueType);
        var valueStr = ValueType switch {
            SecpolRegType.None        => string.Empty,
            SecpolRegType.String      => GetString(),
            SecpolRegType.DoubleWord  => GetDoubleWord().ToString(),
            SecpolRegType.MultiString =>
                $"{{ {string.Join(", ", GetMultiString().Select(x => $"\"{x.Replace("\\", "\\\\").Replace("\"", "\\\"")}\"").ToList())} }}",
            _                                => ""
        };
        return $"{typeName} {valueStr}";
    }
}