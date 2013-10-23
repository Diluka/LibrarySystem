namespace LibraryManagement
{
    partial class FrmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTextBox1 = new LabeledTextBox.LabelTextBox();
            this.SuspendLayout();
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelTextBox1.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.labelTextBox1.LabelText = "用户名";
            this.labelTextBox1.Location = new System.Drawing.Point(87, 67);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Size = new System.Drawing.Size(158, 21);
            this.labelTextBox1.TabIndex = 0;
            this.labelTextBox1.Text = "用户名";
            this.labelTextBox1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.labelTextBox1);
            this.Name = "FrmLogin";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabeledTextBox.LabelTextBox labelTextBox1;
    }
}

