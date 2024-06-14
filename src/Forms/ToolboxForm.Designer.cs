namespace PatchSentry.Forms
{
    partial class ToolboxForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolboxForm));
            BtnAccounts = new Button();
            BtnExit = new Button();
            BtnPolicies = new Button();
            BtnLogs = new Button();
            BtnPrograms = new Button();
            BtnServices = new Button();
            BtnShortcuts = new Button();
            BtnFiles = new Button();
            SuspendLayout();
            // 
            // BtnAccounts
            // 
            BtnAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            BtnAccounts.Location = new Point(12, 12);
            BtnAccounts.Name = "BtnAccounts";
            BtnAccounts.Size = new Size(75, 23);
            BtnAccounts.TabIndex = 0;
            BtnAccounts.Text = "Accounts";
            BtnAccounts.UseVisualStyleBackColor = true;
            BtnAccounts.Click += BtnAccounts_Click;
            // 
            // BtnExit
            // 
            BtnExit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            BtnExit.Location = new Point(937, 12);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(75, 23);
            BtnExit.TabIndex = 1;
            BtnExit.Text = "Exit";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // BtnPolicies
            // 
            BtnPolicies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            BtnPolicies.Location = new Point(93, 12);
            BtnPolicies.Name = "BtnPolicies";
            BtnPolicies.Size = new Size(75, 23);
            BtnPolicies.TabIndex = 2;
            BtnPolicies.Text = "Policies";
            BtnPolicies.UseVisualStyleBackColor = true;
            BtnPolicies.Click += BtnPolicies_Click;
            // 
            // BtnLogs
            // 
            BtnLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            BtnLogs.Location = new Point(856, 12);
            BtnLogs.Name = "BtnLogs";
            BtnLogs.Size = new Size(75, 23);
            BtnLogs.TabIndex = 3;
            BtnLogs.Text = "Logs";
            BtnLogs.UseVisualStyleBackColor = true;
            BtnLogs.Click += BtnLogs_Click;
            // 
            // BtnPrograms
            // 
            BtnPrograms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            BtnPrograms.Location = new Point(174, 12);
            BtnPrograms.Name = "BtnPrograms";
            BtnPrograms.Size = new Size(75, 23);
            BtnPrograms.TabIndex = 4;
            BtnPrograms.Text = "Programs";
            BtnPrograms.UseVisualStyleBackColor = true;
            BtnPrograms.Click += BtnPrograms_Click;
            // 
            // BtnServices
            // 
            BtnServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            BtnServices.Location = new Point(255, 12);
            BtnServices.Name = "BtnServices";
            BtnServices.Size = new Size(75, 23);
            BtnServices.TabIndex = 5;
            BtnServices.Text = "Services";
            BtnServices.UseVisualStyleBackColor = true;
            BtnServices.Click += BtnServices_Click;
            // 
            // BtnShortcuts
            // 
            BtnShortcuts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            BtnShortcuts.Location = new Point(775, 12);
            BtnShortcuts.Name = "BtnShortcuts";
            BtnShortcuts.Size = new Size(75, 23);
            BtnShortcuts.TabIndex = 6;
            BtnShortcuts.Text = "Info";
            BtnShortcuts.UseVisualStyleBackColor = true;
            BtnShortcuts.Click += BtnShortcuts_Click;
            // 
            // BtnFiles
            // 
            BtnFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            BtnFiles.Location = new Point(336, 12);
            BtnFiles.Name = "BtnFiles";
            BtnFiles.Size = new Size(75, 23);
            BtnFiles.TabIndex = 7;
            BtnFiles.Text = "Files";
            BtnFiles.UseVisualStyleBackColor = true;
            BtnFiles.Click += BtnFiles_Click;
            // 
            // ToolboxForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 47);
            Controls.Add(BtnFiles);
            Controls.Add(BtnShortcuts);
            Controls.Add(BtnServices);
            Controls.Add(BtnPrograms);
            Controls.Add(BtnLogs);
            Controls.Add(BtnPolicies);
            Controls.Add(BtnExit);
            Controls.Add(BtnAccounts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ToolboxForm";
            Text = "epic hacker tool";
            Load += Main_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnAccounts;
        private Button BtnExit;
        private Button BtnPolicies;
        private Button BtnLogs;
        private Button BtnPrograms;
        private Button BtnServices;
        private Button BtnShortcuts;
        private Button BtnFiles;
    }
}
