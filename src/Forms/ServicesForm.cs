using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace PatchSentry.Forms;

public partial class ServicesForm : ToolFormBase {
    public ServicesForm() {
        InitializeComponent();
    }

    private async void ServicesForm_Load(object sender, EventArgs e) {
        var assembly = Assembly.GetExecutingAssembly();
        var resource = assembly.GetManifestResourceNames()
            .FirstOrDefault(x => x.EndsWith("Services.Patches.json"));

        await using var patchStream = assembly.GetManifestResourceStream(resource!);
        if (patchStream == null) {
            MessageBox.Show(@"Failed to load patches");
            return;
        }

        var patchReader = new StreamReader(patchStream);
        var patchJson = await patchReader.ReadToEndAsync();

        var patches = JsonConvert.DeserializeObject<Dictionary<string, string>>(patchJson)!;
        patches = patches.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        foreach (var patch in patches) {
            var condSplit = patch.Value.Split(" if ");
            var conditionExists = condSplit.Length > 1;

            var patchNode = new TreeNode(patch.Key) {
                Tag = patch.Key,
                ForeColor = conditionExists ? Color.DarkOrange : Color.Red
            };

            if (conditionExists) {
                var condNode = new TreeNode("if " + condSplit[1]);
                patchNode.Nodes.Add(condNode);
            }

            ListServices.Nodes.Add(patchNode);
        }
    }

    private void button5_Click(object sender, EventArgs e) {
        Process.Start(new ProcessStartInfo("services.msc") {
            UseShellExecute = true
        });
    }

    private void button1_Click(object sender, EventArgs e) {
        Process.Start(new ProcessStartInfo("cmd.exe") {
            Arguments = $"/c \"sc config \"{ListServices.SelectedNode?.Tag}\" start=\"disabled\" & pause\"",
            UseShellExecute = true,
            CreateNoWindow = false,
            WindowStyle = ProcessWindowStyle.Normal,
        });
    }

    private void button3_Click(object sender, EventArgs e) {
        Process.Start(new ProcessStartInfo("cmd.exe") {
            Arguments = $"/c \"sc stop \"{ListServices.SelectedNode?.Tag}\" & pause\"",
            UseShellExecute = true,
            CreateNoWindow = false,
            WindowStyle = ProcessWindowStyle.Normal,
        });
    }

    private void button2_Click(object sender, EventArgs e) {
        throw new NotImplementedException();
    }
}