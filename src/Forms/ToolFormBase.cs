using PatchSentry.Utilities;

namespace PatchSentry.Forms {
    public partial class ToolFormBase : Form {
        public ToolFormBase() {
            InitializeComponent();
            FormClosing += OnFormClosing;
        }

        void OnFormClosing(object? sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}
