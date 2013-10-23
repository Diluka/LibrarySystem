namespace LibraryManagement
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.btnLog = new System.Windows.Forms.Button();
            this.txtUser = new LabeledTextBox.LabelTextBox();
            this.txtPwd = new LabeledTextBox.LabelTextBox();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "D:\\MyBackup\\我的文档\\Visual Studio 2012\\Projects\\WindowsFormsApplication11\\WindowsFor" +
    "msApplication11\\skin\\DiamondBlue.ssk";
            this.skinEngine1.SkinStreamMain = ((System.IO.Stream)(resources.GetObject("skinEngine1.SkinStreamMain")));
            // 
            // btnLog
            // 
            this.btnLog.Font = new System.Drawing.Font("叶根友毛笔行书2.0版", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLog.Location = new System.Drawing.Point(96, 237);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(168, 49);
            this.btnLog.TabIndex = 4;
            this.btnLog.Text = "登    录";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUser
            // 
            this.txtUser.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtUser.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtUser.LabelText = "用户名";
            this.txtUser.Location = new System.Drawing.Point(155, 126);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(181, 21);
            this.txtUser.TabIndex = 5;
            this.txtUser.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // txtPwd
            // 
            this.txtPwd.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtPwd.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtPwd.LabelText = "密码";
            this.txtPwd.Location = new System.Drawing.Point(155, 167);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(181, 21);
            this.txtPwd.TabIndex = 6;
            this.txtPwd.TextColor = System.Drawing.SystemColors.ControlText;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources.登录背景;
            this.ClientSize = new System.Drawing.Size(360, 298);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnLog);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button btnLog;
        private LabeledTextBox.LabelTextBox txtUser;
        private LabeledTextBox.LabelTextBox txtPwd;
    }
}