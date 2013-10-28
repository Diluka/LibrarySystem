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
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtSearchString = new LabeledTextBox.LabelTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeCategories = new System.Windows.Forms.TreeView();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(13, 455);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(159, 23);
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "删除已选出版社";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(236, 455);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清除选择";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnGo);
            this.groupBox2.Controls.Add(this.txtSearchString);
            this.groupBox2.Location = new System.Drawing.Point(13, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 45);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出版社查询";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(291, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(82, 23);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "新增出版社";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(210, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "搜索";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // txtSearchString
            // 
            this.txtSearchString.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtSearchString.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtSearchString.LabelText = "输入列别名称";
            this.txtSearchString.Location = new System.Drawing.Point(6, 12);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(198, 21);
            this.txtSearchString.TabIndex = 0;
            this.txtSearchString.Text = "输入列别名称";
            this.txtSearchString.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeCategories);
            this.groupBox1.Location = new System.Drawing.Point(13, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 390);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出版社选择";
            // 
            // treeCategories
            // 
            this.treeCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategories.Location = new System.Drawing.Point(3, 17);
            this.treeCategories.Name = "treeCategories";
            this.treeCategories.Size = new System.Drawing.Size(373, 370);
            this.treeCategories.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(317, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关    闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmBookPressManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 494);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBookPressManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出版社设置";
            this.Load += new System.EventHandler(this.FrmBookconcernManager_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnGo;
        private LabeledTextBox.LabelTextBox txtSearchString;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeCategories;
        private System.Windows.Forms.Button btnClose;

    }
}