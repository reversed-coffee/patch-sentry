namespace PatchSentry.Forms {
    partial class ProgramForm {
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
            textBox1 = new TextBox();
            BtnSearch = new Button();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            groupBox5 = new GroupBox();
            button6 = new Button();
            groupBox4 = new GroupBox();
            button1 = new Button();
            button4 = new Button();
            button2 = new Button();
            groupBox3 = new GroupBox();
            button8 = new Button();
            button9 = new Button();
            groupBox2 = new GroupBox();
            button3 = new Button();
            button5 = new Button();
            treeView1 = new TreeView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(107, 23);
            textBox1.TabIndex = 0;
            // 
            // BtnSearch
            // 
            BtnSearch.Location = new Point(119, 23);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(53, 23);
            BtnSearch.TabIndex = 2;
            BtnSearch.Text = "Filter";
            BtnSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(treeView1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(628, 345);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Programs";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.hacker_epic;
            pictureBox1.Location = new Point(300, 214);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(317, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button6);
            groupBox5.Controls.Add(textBox1);
            groupBox5.Controls.Add(BtnSearch);
            groupBox5.Location = new Point(438, 118);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(179, 90);
            groupBox5.TabIndex = 10;
            groupBox5.TabStop = false;
            groupBox5.Text = "Filter Operations";
            // 
            // button6
            // 
            button6.Location = new Point(6, 55);
            button6.Name = "button6";
            button6.Size = new Size(166, 27);
            button6.TabIndex = 3;
            button6.Text = "Clear Filter";
            button6.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(button2);
            groupBox4.Location = new Point(432, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(185, 90);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Scan Operations";
            // 
            // button1
            // 
            button1.Location = new Point(6, 22);
            button1.Name = "button1";
            button1.Size = new Size(113, 27);
            button1.TabIndex = 1;
            button1.Text = "Rescan Portable";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(125, 22);
            button4.Name = "button4";
            button4.Size = new Size(53, 60);
            button4.TabIndex = 4;
            button4.Text = "Rescan All";
            button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(6, 55);
            button2.Name = "button2";
            button2.Size = new Size(113, 27);
            button2.TabIndex = 2;
            button2.Text = "Rescan Registered";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button8);
            groupBox3.Controls.Add(button9);
            groupBox3.Location = new Point(300, 118);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(126, 90);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Registry Operations";
            // 
            // button8
            // 
            button8.Location = new Point(6, 22);
            button8.Name = "button8";
            button8.Size = new Size(113, 27);
            button8.TabIndex = 3;
            button8.Text = "Uninstall/Modify";
            button8.TextAlign = ContentAlignment.MiddleLeft;
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(6, 55);
            button9.Name = "button9";
            button9.Size = new Size(113, 27);
            button9.TabIndex = 4;
            button9.Text = "Unregister";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button5);
            groupBox2.Location = new Point(300, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(126, 90);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Disk Operations";
            // 
            // button3
            // 
            button3.Location = new Point(6, 22);
            button3.Name = "button3";
            button3.Size = new Size(113, 27);
            button3.TabIndex = 3;
            button3.Text = "Delete";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(6, 55);
            button5.Name = "button5";
            button5.Size = new Size(113, 27);
            button5.TabIndex = 4;
            button5.Text = "Move";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(6, 22);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(288, 317);
            treeView1.TabIndex = 0;
            // 
            // ProgramForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 419);
            Controls.Add(groupBox1);
            Name = "ProgramForm";
            Text = "Program Manager";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Button BtnSearch;
        private GroupBox groupBox1;
        private Button button2;
        private Button button1;
        private TreeView treeView1;
        private Button button3;
        private Button button5;
        private Button button4;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private Button button8;
        private Button button9;
        private GroupBox groupBox2;
        private PictureBox pictureBox1;
        private GroupBox groupBox5;
        private Button button6;
    }
}