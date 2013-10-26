namespace LibraryManagement
{
    partial class frmBookPressManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBookPressManager));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvBookconcern = new System.Windows.Forms.ListView();
            this.出版社名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelTextBox1 = new LabeledTextBox.LabelTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvBookconcern);
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出版社";
            // 
            // lvBookconcern
            // 
            this.lvBookconcern.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lvBookconcern.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.出版社名称});
            this.lvBookconcern.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvBookconcern.FullRowSelect = true;
            this.lvBookconcern.Location = new System.Drawing.Point(3, 17);
            this.lvBookconcern.Name = "lvBookconcern";
            this.lvBookconcern.Size = new System.Drawing.Size(350, 374);
            this.lvBookconcern.TabIndex = 0;
            this.lvBookconcern.UseCompatibleStateImageBehavior = false;
            this.lvBookconcern.View = System.Windows.Forms.View.Details;
            // 
            // 出版社名称
            // 
            this.出版社名称.Text = "出版社名称";
            this.出版社名称.Width = 346;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTextBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出版社查询";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "名称：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 490);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "确        定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(213, 490);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "取         消";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelTextBox1.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.labelTextBox1.LabelText = "请输入出版社名称";
            this.labelTextBox1.Location = new System.Drawing.Point(75, 25);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Size = new System.Drawing.Size(181, 21);
            this.labelTextBox1.TabIndex = 5;
            this.labelTextBox1.Text = "请输入出版社名称";
            this.labelTextBox1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // frmBookPressManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 535);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBookPressManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出版社设置";
            this.Load += new System.EventHandler(this.FrmBookconcernManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvBookconcern;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader 出版社名称;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private LabeledTextBox.LabelTextBox labelTextBox1;
    }
}