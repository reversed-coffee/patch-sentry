namespace PatchSentry.Forms {
    partial class ServicesForm {
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
            button2 = new Button();
            button3 = new Button();
            ListServices = new TreeView();
            button5 = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(ListServices);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 345);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "CIS Benchmark Patch Tool (just enough to get cybpat workin lol)";
            // 
            // button2
            // 
            button2.Location = new Point(288, 22);
            button2.Name = "button2";
            button2.Size = new Size(88, 27);
            button2.TabIndex = 5;
            button2.Text = "Start";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(194, 22);
            button3.Name = "button3";
            button3.Size = new Size(88, 27);
            button3.TabIndex = 6;
            button3.Text = "sotp";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ListServices
            // 
            ListServices.Location = new Point(6, 55);
            ListServices.Name = "ListServices";
            ListServices.Size = new Size(370, 284);
            ListServices.TabIndex = 0;
            // 
            // button5
            // 
            button5.Location = new Point(100, 22);
            button5.Name = "button5";
            button5.Size = new Size(88, 27);
            button5.TabIndex = 4;
            button5.Text = "open mgr";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(6, 22);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 3;
            button1.Text = "fast disable";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ServicesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 373);
            Controls.Add(groupBox1);
            Name = "ServicesForm";
            Text = "Service Manager";
            Load += ServicesForm_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TreeView ListServices;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button5;
    }
}