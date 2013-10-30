namespace LibraryManagement
{
    partial class FrmAdminMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminMain));
            this.btnBookmanage = new System.Windows.Forms.Button();
            this.btnLeasemanage = new System.Windows.Forms.Button();
            this.btnDatamanage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBookmanage
            // 
            this.btnBookmanage.BackColor = System.Drawing.Color.Transparent;
            this.btnBookmanage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBookmanage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookmanage.Location = new System.Drawing.Point(74, 55);
            this.btnBookmanage.Name = "btnBookmanage";
            this.btnBookmanage.Size = new System.Drawing.Size(218, 77);
            this.btnBookmanage.TabIndex = 0;
            this.btnBookmanage.Text = "书籍管理";
            this.btnBookmanage.UseVisualStyleBackColor = false;
            this.btnBookmanage.Click += new System.EventHandler(this.button1_Click);
            this.btnBookmanage.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnBookmanage.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // btnLeasemanage
            // 
            this.btnLeasemanage.BackColor = System.Drawing.Color.Transparent;
            this.btnLeasemanage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLeasemanage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeasemanage.Location = new System.Drawing.Point(74, 173);
            this.btnLeasemanage.Name = "btnLeasemanage";
            this.btnLeasemanage.Size = new System.Drawing.Size(218, 77);
            this.btnLeasemanage.TabIndex = 1;
            this.btnLeasemanage.Text = "租借管理";
            this.btnLeasemanage.UseVisualStyleBackColor = false;
            this.btnLeasemanage.Click += new System.EventHandler(this.button2_Click);
            this.btnLeasemanage.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnLeasemanage.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // btnDatamanage
            // 
            this.btnDatamanage.BackColor = System.Drawing.Color.Transparent;
            this.btnDatamanage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDatamanage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatamanage.Location = new System.Drawing.Point(74, 291);
            this.btnDatamanage.Name = "btnDatamanage";
            this.btnDatamanage.Size = new System.Drawing.Size(218, 77);
            this.btnDatamanage.TabIndex = 2;
            this.btnDatamanage.Text = "数据管理";
            this.btnDatamanage.UseVisualStyleBackColor = false;
            this.btnDatamanage.Click += new System.EventHandler(this.button3_Click);
            this.btnDatamanage.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnDatamanage.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(74, 409);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(218, 77);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "关        于";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // FrmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources.主窗体背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDatamanage);
            this.Controls.Add(this.btnLeasemanage);
            this.Controls.Add(this.btnBookmanage);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmAdminMain";
            this.Text = "管理员";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Adm_FormClosed);
            this.Load += new System.EventHandler(this.FrmAdminMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBookmanage;
        private System.Windows.Forms.Button btnLeasemanage;
        private System.Windows.Forms.Button btnDatamanage;
        private System.Windows.Forms.Button btnExit;
    }
}

