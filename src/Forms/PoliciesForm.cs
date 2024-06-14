using System.Diagnostics;
using System.Reflection;

using Newtonsoft.Json;

using PatchSentry.Secpol;
using PatchSentry.Secpol.Policies;
using PatchSentry.Utilities;

namespace PatchSentry.Forms;

public partial class PoliciesForm : ToolFormBase {
    public Secpol.SecpolContainer SecPol = new();
    public bool UnwrittenChanges;

    public PoliciesForm() {
        InitializeComponent();
        FormClosing += PoliciesForm_FormClosing;
    }

    private void PoliciesForm_FormClosing(object? sender, FormClosingEventArgs e) {
        // Check if we have unwritten changes
        if (!UnwrittenChanges)
            return;

        // Ask the user if they want to save
        var result = MessageBox.Show(@"You have not saved the local security database. Are you sure you want to exit?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
            return;

        e.Cancel = true;
        Show();
    }

    async Task LoadSecPolAsync() {
        ListSecPol.Nodes.Clear();
        await SecPol.ImportAsync();

        foreach (var section in SecPol.Sections.Values) {
            if (section.Name is "Unicode" or "Version") // Skip these sections
                continue;

            var sectionNode = new TreeNode(section.Name) { Name = section.Name, Tag = section };

            foreach (var policy in section.Policies) {
                var policyNode = new TreeNode($"{policy.Name}") { Name = policy.Name, Tag = policy };

                var policyValueNode = new TreeNode(policy.ToString()) { Name = "Value", ForeColor = Color.Red };
                policyNode.Nodes.Add(policyValueNode);

                sectionNode.Nodes.Add(policyNode);
            }

            ListSecPol.Nodes.Add(sectionNode);
        }
    }

    async Task LoadPatchesAsync() {
        var assembly = Assembly.GetExecutingAssembly();
        var resource = assembly.GetManifestResourceNames()
            .FirstOrDefault(x => x.EndsWith("Secpol.Patches.json"));

        await using var patchStream = assembly.GetManifestResourceStream(resource!);
        if (patchStream == null) {
            MessageBox.Show(@"Failed to load patches");
            return;
        }

        using var patchReader = new StreamReader(patchStream);
        var patchJson = await patchReader.ReadToEndAsync();
        var sections = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(patchJson)!;

        foreach (var section in sections) {
            var foundNode = ListSecPol.Nodes.Find(section.Key, false).FirstOrDefault();
            if (foundNode == null) {
                Program.State.Logger.Send($"Failed to find section node for '{foundNode}");
                continue;
            }

            foreach (var policy in section.Value) {
                var foundPolicyNode = foundNode.Nodes.Find(policy.Key, false).FirstOrDefault();

                if (foundPolicyNode == null) {
                    Program.State.Logger.Send($"Failed to find policy node for '{policy.Key}'");
                    continue;
                }

                throw new NotImplementedException();

                /*var fakePolicy = Secpol.SecpolContainer.ConvertPolicy(new(policy.Key, policy.Value), Secpol.SecpolContainer.GetTypeFromSection(section.Key));
                if (fakePolicy.ToString() == foundPolicyNode.Tag.ToString())
                    continue;

                // Expand node to show changes
                foundPolicyNode.Expand();

                // Add new patch node
                var patchNode = new TreeNode(policy.Value) {
                    Name = "ValuePatch",
                    Tag = fakePolicy,
                    ForeColor = Color.Blue
                };

                // Traverse parents make orange
                var parent = foundPolicyNode.Parent;
                while (parent != null) {
                    parent.ForeColor = Color.DarkOrange;
                    parent = parent.Parent;
                }

                foundPolicyNode.ForeColor = Color.Green;
                foundPolicyNode.Nodes.Add(patchNode);*/
            }
        }
    }

    private async void PolicyManagement_Load(object sender, EventArgs e) {
        await LoadSecPolAsync();
        await LoadPatchesAsync();
    }

    private async void BtnReloadView_Click(object sender, EventArgs e) {
        await LoadSecPolAsync();
    }

    private async void BtnLoadPatches_Click(object sender, EventArgs e) {
        await LoadPatchesAsync();
    }

    private void BtnOpenGpedit_Click(object sender, EventArgs e) {
        Process.Start(new ProcessStartInfo("gpedit.msc") {
            UseShellExecute = true
        });
    }

    private void BtnUpdateGroupPolicies_Click(object sender, EventArgs e) {
        Process.Start(new ProcessStartInfo("cmd") {
            Arguments = "/c \"gpupdate /force && pause\"",
            UseShellExecute = true
        });
    }

    private void BtnClose_Click(object sender, EventArgs e) {
        foreach (var node in ListSecPol.Nodes.Cast<TreeNode>().ToList()) {
            foreach (var policyNode in node.Nodes.Cast<TreeNode>().ToList()
                         .Where(policyNode => policyNode.ForeColor != Color.Green))
                policyNode.Remove();
            node.Expand();
        }
    }

    private void BtnApplyPatch_Click(object sender, EventArgs e) {
        var node = ListSecPol.SelectedNode;

        if (node == null) {
            MessageBox.Show(@"No node selected", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var type = node.Tag?.GetType();
        if (type != typeof(SecpolBase) && type?.IsSubclassOf(typeof(SecpolBase)) is false) {
            MessageBox.Show(@"Please select a policy first", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var patchNode = node.Nodes.Find("ValuePatch", false).FirstOrDefault();
        if (patchNode == null) {
            MessageBox.Show(@"No patch exists for this node", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        throw new NotImplementedException();
        //((SecpolBase)node.Tag!).RawValue = ((SecpolBase)patchNode.Tag!).RawValue;
        node.Remove();

        if (!UnwrittenChanges)
            UnwrittenChanges = true;
    }

    private void ListSecPol_AfterSelect(object sender, TreeViewEventArgs e) {

    }

    private async void BtnUpdateSecpol_Click(object sender, EventArgs e) {
        await SecPol.ExportAsync();
        UnwrittenChanges = false;
        MessageBox.Show(@"Successfully updated local security database", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnNext_Click(object sender, EventArgs e) {
        // shift selected node to next
        var node = ListSecPol.SelectedNode;
        var nextNode = node?.NextNode ?? node?.Parent;
        if (nextNode == null)
            return;
        ListSecPol.SelectedNode = nextNode;
    }

    private void BtnLast_Click(object sender, EventArgs e) {
        // shift selected node to last
        var node = ListSecPol.SelectedNode;
        var lastNode = node?.PrevNode ?? node?.Parent;
        if (lastNode == null)
            return;
        ListSecPol.SelectedNode = lastNode;
    }
}