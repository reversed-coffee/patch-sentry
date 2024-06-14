namespace PatchSentry.Forms {
    partial class PoliciesForm {
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
            groupBox1 = new GroupBox();
            BtnLast = new Button();
            BtnNext = new Button();
            BtnUpdateSecpol = new Button();
            BtnLoadPatches = new Button();
            BtnApplyPatch = new Button();
            BtnClose = new Button();
            BtnReloadView = new Button();
            ListSecPol = new TreeView();
            groupBox2 = new GroupBox();
            BtnUpdateGroupPolicies = new Button();
            BtnOpenGpedit = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(BtnLast);
            groupBox1.Controls.Add(BtnNext);
            groupBox1.Controls.Add(BtnUpdateSecpol);
            groupBox1.Controls.Add(BtnLoadPatches);
            groupBox1.Controls.Add(BtnApplyPatch);
            groupBox1.Controls.Add(BtnClose);
            groupBox1.Controls.Add(BtnReloadView);
            groupBox1.Controls.Add(ListSecPol);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(433, 366);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Security Policy";
            // 
            // BtnLast
            // 
            BtnLast.Location = new Point(327, 121);
            BtnLast.Name = "BtnLast";
            BtnLast.Size = new Size(45, 27);
            BtnLast.TabIndex = 10;
            BtnLast.Text = "<<";
            BtnLast.UseVisualStyleBackColor = true;
            BtnLast.Click += BtnLast_Click;
            // 
            // BtnNext
            // 
            BtnNext.Location = new Point(382, 121);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(45, 27);
            BtnNext.TabIndex = 9;
            BtnNext.Text = ">>";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // BtnUpdateSecpol
            // 
            BtnUpdateSecpol.Location = new Point(327, 88);
            BtnUpdateSecpol.Name = "BtnUpdateSecpol";
            BtnUpdateSecpol.Size = new Size(100, 27);
            BtnUpdateSecpol.TabIndex = 7;
            BtnUpdateSecpol.Text = "Update DB";
            BtnUpdateSecpol.TextAlign = ContentAlignment.MiddleLeft;
            BtnUpdateSecpol.UseVisualStyleBackColor = true;
            BtnUpdateSecpol.Click += BtnUpdateSecpol_Click;
            // 
            // BtnLoadPatches
            // 
            BtnLoadPatches.Location = new Point(327, 294);
            BtnLoadPatches.Name = "BtnLoadPatches";
            BtnLoadPatches.Size = new Size(100, 27);
            BtnLoadPatches.TabIndex = 6;
            BtnLoadPatches.Text = "Reload Patches";
            BtnLoadPatches.TextAlign = ContentAlignment.MiddleLeft;
            BtnLoadPatches.UseVisualStyleBackColor = true;
            BtnLoadPatches.Click += BtnLoadPatches_Click;
            // 
            // BtnApplyPatch
            // 
            BtnApplyPatch.Location = new Point(327, 22);
            BtnApplyPatch.Name = "BtnApplyPatch";
            BtnApplyPatch.Size = new Size(100, 27);
            BtnApplyPatch.TabIndex = 5;
            BtnApplyPatch.Text = "Apply Patch";
            BtnApplyPatch.TextAlign = ContentAlignment.MiddleLeft;
            BtnApplyPatch.UseVisualStyleBackColor = true;
            BtnApplyPatch.Click += BtnApplyPatch_Click;
            // 
            // BtnClose
            // 
            BtnClose.Location = new Point(327, 55);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(100, 27);
            BtnClose.TabIndex = 4;
            BtnClose.Text = "Show Patches";
            BtnClose.TextAlign = ContentAlignment.MiddleLeft;
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // BtnReloadView
            // 
            BtnReloadView.Location = new Point(327, 327);
            BtnReloadView.Name = "BtnReloadView";
            BtnReloadView.Size = new Size(100, 27);
            BtnReloadView.TabIndex = 3;
            BtnReloadView.Text = "Reload View";
            BtnReloadView.TextAlign = ContentAlignment.MiddleLeft;
            BtnReloadView.UseVisualStyleBackColor = true;
            BtnReloadView.Click += BtnReloadView_Click;
            // 
            // ListSecPol
            // 
            ListSecPol.HideSelection = false;
            ListSecPol.Location = new Point(6, 22);
            ListSecPol.Name = "ListSecPol";
            ListSecPol.Size = new Size(315, 332);
            ListSecPol.TabIndex = 0;
            ListSecPol.AfterSelect += ListSecPol_AfterSelect;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnUpdateGroupPolicies);
            groupBox2.Controls.Add(BtnOpenGpedit);
            groupBox2.Location = new Point(451, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(112, 94);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Group Policy";
            // 
            // BtnUpdateGroupPolicies
            // 
            BtnUpdateGroupPolicies.Location = new Point(6, 55);
            BtnUpdateGroupPolicies.Name = "BtnUpdateGroupPolicies";
            BtnUpdateGroupPolicies.Size = new Size(100, 27);
            BtnUpdateGroupPolicies.TabIndex = 7;
            BtnUpdateGroupPolicies.Text = "Force Update";
            BtnUpdateGroupPolicies.UseVisualStyleBackColor = true;
            BtnUpdateGroupPolicies.Click += BtnUpdateGroupPolicies_Click;
            // 
            // BtnOpenGpedit
            // 
            BtnOpenGpedit.Location = new Point(6, 22);
            BtnOpenGpedit.Name = "BtnOpenGpedit";
            BtnOpenGpedit.Size = new Size(100, 27);
            BtnOpenGpedit.TabIndex = 6;
            BtnOpenGpedit.Text = "Open Editor";
            BtnOpenGpedit.UseVisualStyleBackColor = true;
            BtnOpenGpedit.Click += BtnOpenGpedit_Click;
            // 
            // PoliciesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 388);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "PoliciesForm";
            Text = "Policy Manager";
            Load += PolicyManagement_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private TreeView ListSecPol;
        private Button BtnReloadView;
        private Button BtnApplyPatch;
        private Button BtnClose;
        private GroupBox groupBox2;
        private Button BtnUpdateGroupPolicies;
        private Button BtnOpenGpedit;
        private Button BtnLoadPatches;
        private Button BtnUpdateSecpol;
        private Button BtnLast;
        private Button BtnNext;
    }
}