using System.Diagnostics;
using System.DirectoryServices.AccountManagement;

using PatchSentry.Accounts;
using PatchSentry.Utilities;

namespace PatchSentry.Forms;

public partial class ToolboxForm : Form {
    const int WindowOffset = 25;

    public ToolboxForm() {
#   if !DEBUG
        TopMost = true;
#   endif
        InitializeComponent();

        var thisScreen = Screen.FromControl(this);
        Location = new(WindowOffset, WindowOffset);
        Size = new(new(thisScreen.WorkingArea.Width - WindowOffset * 2, Size.Height));
    }

    private void BtnAccounts_Click(object sender, EventArgs e) {
        FormExtensions.Display<AccountsForm>();
    }

    private void Main_Load(object sender, EventArgs e) {
        // i use this function to test random crap
    }

    private void BtnExit_Click(object sender, EventArgs e) {
        Close();
    }

    private void BtnPolicies_Click(object sender, EventArgs e) {
        FormExtensions.Display<PoliciesForm>();
    }

    private void BtnLogs_Click(object sender, EventArgs e) {
        FormExtensions.Display<LogsForm>();
    }

    private void BtnPrograms_Click(object sender, EventArgs e) {
        FormExtensions.Display<ProgramForm>();
    }

    private void BtnServices_Click(object sender, EventArgs e) {
        FormExtensions.Display<ServicesForm>();
    }

    private void BtnShortcuts_Click(object sender, EventArgs e) {
        FormExtensions.Display<ShortcutsForm>();
    }

    private void BtnFiles_Click(object sender, EventArgs e) {
        FormExtensions.Display<FilesForm>();
    }
}