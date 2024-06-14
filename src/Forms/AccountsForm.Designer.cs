namespace PatchSentry.Forms {
    partial class AccountsForm {
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
            var treeNode1 = new TreeNode("Administrators");
            var treeNode2 = new TreeNode("Users");
            var treeNode3 = new TreeNode("Administrator", new TreeNode[] { treeNode1, treeNode2 });
            groupBox1 = new GroupBox();
            BtnRefreshQuickList = new Button();
            BtnPatchQuick = new Button();
            BtnDisableQuick = new Button();
            BtnDeleteQuick = new Button();
            ListQuickManager = new TreeView();
            groupBox2 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            BoxSetAdmins = new RichTextBox();
            BtnSetUsers = new Button();
            BoxSetUsers = new RichTextBox();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnRefreshQuickList);
            groupBox1.Controls.Add(BtnPatchQuick);
            groupBox1.Controls.Add(BtnDisableQuick);
            groupBox1.Controls.Add(BtnDeleteQuick);
            groupBox1.Controls.Add(ListQuickManager);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(396, 315);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Accounts";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // BtnRefreshQuickList
            // 
            BtnRefreshQuickList.Location = new Point(306, 282);
            BtnRefreshQuickList.Name = "BtnRefreshQuickList";
            BtnRefreshQuickList.Size = new Size(84, 27);
            BtnRefreshQuickList.TabIndex = 4;
            BtnRefreshQuickList.Text = "Reset View";
            BtnRefreshQuickList.TextAlign = ContentAlignment.MiddleLeft;
            BtnRefreshQuickList.UseVisualStyleBackColor = true;
            BtnRefreshQuickList.Click += BtnRefreshQuickList_Click;
            // 
            // BtnPatchQuick
            // 
            BtnPatchQuick.Location = new Point(306, 85);
            BtnPatchQuick.Name = "BtnPatchQuick";
            BtnPatchQuick.Size = new Size(84, 27);
            BtnPatchQuick.TabIndex = 3;
            BtnPatchQuick.Text = "Patch";
            BtnPatchQuick.TextAlign = ContentAlignment.MiddleLeft;
            BtnPatchQuick.UseVisualStyleBackColor = true;
            BtnPatchQuick.Click += BtnPatchQuick_Click;
            // 
            // BtnDisableQuick
            // 
            BtnDisableQuick.Location = new Point(306, 52);
            BtnDisableQuick.Name = "BtnDisableQuick";
            BtnDisableQuick.Size = new Size(84, 27);
            BtnDisableQuick.TabIndex = 2;
            BtnDisableQuick.Text = "Disable";
            BtnDisableQuick.TextAlign = ContentAlignment.MiddleLeft;
            BtnDisableQuick.UseVisualStyleBackColor = true;
            BtnDisableQuick.Click += BtnDisableQuick_Click;
            // 
            // BtnDeleteQuick
            // 
            BtnDeleteQuick.Location = new Point(306, 19);
            BtnDeleteQuick.Name = "BtnDeleteQuick";
            BtnDeleteQuick.Size = new Size(84, 27);
            BtnDeleteQuick.TabIndex = 1;
            BtnDeleteQuick.Text = "Delete";
            BtnDeleteQuick.TextAlign = ContentAlignment.MiddleLeft;
            BtnDeleteQuick.UseVisualStyleBackColor = true;
            BtnDeleteQuick.Click += BtnDeleteQuick_Click;
            // 
            // ListQuickManager
            // 
            ListQuickManager.HideSelection = false;
            ListQuickManager.Location = new Point(6, 22);
            ListQuickManager.Name = "ListQuickManager";
            treeNode1.Name = "__reserved_node0_chnode1";
            treeNode1.Text = "Administrators";
            treeNode2.Name = "__reserved_node0_chnode2";
            treeNode2.Text = "Users";
            treeNode3.Name = "__reserved_node0";
            treeNode3.Text = "Administrator";
            ListQuickManager.Nodes.AddRange(new TreeNode[] { treeNode3 });
            ListQuickManager.Size = new Size(294, 287);
            ListQuickManager.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(BoxSetAdmins);
            groupBox2.Controls.Add(BtnSetUsers);
            groupBox2.Controls.Add(BoxSetUsers);
            groupBox2.Location = new Point(414, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(230, 215);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Account Lists";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 22);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 4;
            label2.Text = "Admin Accounts";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 3;
            label1.Text = "User Accounts";
            // 
            // BoxSetAdmins
            // 
            BoxSetAdmins.Location = new Point(118, 40);
            BoxSetAdmins.Name = "BoxSetAdmins";
            BoxSetAdmins.Size = new Size(106, 135);
            BoxSetAdmins.TabIndex = 2;
            BoxSetAdmins.Text = "edward\njohn\ndave";
            // 
            // BtnSetUsers
            // 
            BtnSetUsers.Location = new Point(6, 181);
            BtnSetUsers.Name = "BtnSetUsers";
            BtnSetUsers.RightToLeft = RightToLeft.No;
            BtnSetUsers.Size = new Size(218, 27);
            BtnSetUsers.TabIndex = 1;
            BtnSetUsers.Text = "Set Authorized Users";
            BtnSetUsers.UseVisualStyleBackColor = true;
            BtnSetUsers.Click += BtnSetUsers_Click;
            // 
            // BoxSetUsers
            // 
            BoxSetUsers.Location = new Point(6, 40);
            BoxSetUsers.Name = "BoxSetUsers";
            BoxSetUsers.Size = new Size(106, 135);
            BoxSetUsers.TabIndex = 0;
            BoxSetUsers.Text = "james\nevan\nsamantha\nrobert\nsophie";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = Properties.Resources.pug;
            pictureBox1.Location = new Point(414, 233);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(224, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // AccountsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 336);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "AccountsForm";
            Text = "Account Manager";
            Load += AccountManagement_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TreeView ListQuickManager;
        private Button BtnDisableQuick;
        private Button BtnDeleteQuick;
        private GroupBox groupBox2;
        private Button BtnSetAdmins;
        private RichTextBox BoxSetAdmins;
        private Button BtnSetUsers;
        private RichTextBox BoxSetUsers;
        private Button BtnPatchQuick;
        private Button BtnRefreshQuickList;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
    }
}