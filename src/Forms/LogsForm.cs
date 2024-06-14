using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatchSentry.Forms;

public partial class LogsForm : ToolFormBase {
    public LogsForm() {
        InitializeComponent();
    }

    private void BtnClear_Click(object sender, EventArgs e) {
        LogBox.Clear();
    }

    private void Logs_Load(object sender, EventArgs e) {
        Program.State.Logger.AttachTextBox(LogBox);
    }

    private void LogBox_TextChanged(object sender, EventArgs e) {
        if (ChkScrollToEnd.Checked)
            LogBox.ScrollToCaret();
    }
}