using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatchSentry.Forms;

public partial class ShortcutsForm : ToolFormBase {
    public ShortcutsForm() {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e) {
        Process.Start(new ProcessStartInfo("cmd.exe") { UseShellExecute = true });
    }

    private async void ShortcutsForm_Load(object sender, EventArgs e) {
        var assembly = Assembly.GetExecutingAssembly();
        var resource = assembly.GetManifestResourceNames()
            .FirstOrDefault(x => x.EndsWith("CybpatNotes.md"));

        await using var patchStream = assembly.GetManifestResourceStream(resource!);
        if (patchStream == null) {
            MessageBox.Show(@"Failed to load patches");
            return;
        }

        var reader = new StreamReader(patchStream);
        var notes = await reader.ReadToEndAsync();

        richTextBox1.Text = notes;
    }
}