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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new LabeledTextBox.LabelTextBox();
            this.txtUsername = new LabeledTextBox.LabelTextBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.cboSkins = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(96, 237);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(168, 49);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登    录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.LabelText = "密码";
            this.txtPassword.Location = new System.Drawing.Point(155, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(181, 21);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.LabelText = "用户名";
            this.txtUsername.Location = new System.Drawing.Point(155, 126);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(181, 21);
            this.txtUsername.TabIndex = 5;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "";
            this.skinEngine1.TitleFont = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // cboSkins
            // 
            this.cboSkins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSkins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSkins.FormattingEnabled = true;
            this.cboSkins.Items.AddRange(new object[] {
            "[系统默认]",
            "平静",
            "深青",
            "砖石蓝",
            "十八",
            "祖母绿",
            "玻璃棕",
            "长角",
            "苹果系统",
            "仲夏",
            "Media Player 10",
            "MSN",
            "OneBlue",
            "页面",
            "RealOne",
            "银色",
            "运动黑",
            "质感黑",
            "Vista1",
            "Vista2",
            "温暖",
            "波纹",
            "XP银"});
            this.cboSkins.Location = new System.Drawing.Point(224, 203);
            this.cboSkins.Name = "cboSkins";
            this.cboSkins.Size = new System.Drawing.Size(112, 20);
            this.cboSkins.TabIndex = 9;
            this.cboSkins.Visible = false;
            this.cboSkins.SelectedIndexChanged += new System.EventHandler(this.cboSkins_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(153, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "界面风格：";
            this.label1.Visible = false;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources.登录背景1111;
            this.ClientSize = new System.Drawing.Size(360, 300);
            this.Controls.Add(this.cboSkins);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private LabeledTextBox.LabelTextBox txtUsername;
        private LabeledTextBox.LabelTextBox txtPassword;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ComboBox cboSkins;
        private System.Windows.Forms.Label label1;
    }
}