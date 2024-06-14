namespace PatchSentry.Forms {
    partial class LogsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            LogBox = new RichTextBox();
            BtnClear = new Button();
            ChkScrollToEnd = new CheckBox();
            SuspendLayout();
            // 
            // LogBox
            // 
            LogBox.Cursor = Cursors.No;
            LogBox.Location = new Point(12, 12);
            LogBox.Name = "LogBox";
            LogBox.ReadOnly = true;
            LogBox.Size = new Size(578, 230);
            LogBox.TabIndex = 0;
            LogBox.Text = "";
            LogBox.TextChanged += LogBox_TextChanged;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(12, 248);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(75, 23);
            BtnClear.TabIndex = 1;
            BtnClear.Text = "Clear";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // ChkScrollToEnd
            // 
            ChkScrollToEnd.AutoSize = true;
            ChkScrollToEnd.Checked = true;
            ChkScrollToEnd.CheckState = CheckState.Checked;
            ChkScrollToEnd.Location = new Point(93, 251);
            ChkScrollToEnd.Name = "ChkScrollToEnd";
            ChkScrollToEnd.Size = new Size(93, 19);
            ChkScrollToEnd.TabIndex = 2;
            ChkScrollToEnd.Text = "Scroll To End";
            ChkScrollToEnd.UseVisualStyleBackColor = true;
            // 
            // Logs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 284);
            Controls.Add(ChkScrollToEnd);
            Controls.Add(BtnClear);
            Controls.Add(LogBox);
            Name = "Logs";
            Text = "Logs";
            Load += Logs_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox LogBox;
        private Button BtnClear;
        private CheckBox ChkScrollToEnd;
    }
}