namespace LibraryManagement
{
    partial class FrmLeaseManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLeaseManager));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.租借ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.续期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.归还ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupUserInfo = new System.Windows.Forms.GroupBox();
            this.btnOK2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtRegDate = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.rdoGirl = new System.Windows.Forms.RadioButton();
            this.rdoBoy = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBookList = new System.Windows.Forms.GroupBox();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.chkIsReadOnly = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfoID = new LabeledTextBox.LabelTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupOrders = new System.Windows.Forms.GroupBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.groupBookList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.groupOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(967, 64);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::LibraryManagement.Properties.Resources.书籍租出;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 61);
            this.toolStripButton1.Text = "书籍租出";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 64);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::LibraryManagement.Properties.Resources.修改书籍;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 61);
            this.toolStripButton2.Text = "书籍续借";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 64);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::LibraryManagement.Properties.Resources.书籍归还;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 61);
            this.toolStripButton3.Text = "书籍归还";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 64);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::LibraryManagement.Properties.Resources.超期信息;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(60, 61);
            this.toolStripButton4.Text = "超期信息";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 64);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 64);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = global::LibraryManagement.Properties.Resources.退出;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(52, 61);
            this.toolStripButton7.Text = "退    出";
            this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.租借ToolStripMenuItem,
            this.续期ToolStripMenuItem,
            this.归还ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // 租借ToolStripMenuItem
            // 
            this.租借ToolStripMenuItem.Name = "租借ToolStripMenuItem";
            this.租借ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.租借ToolStripMenuItem.Text = "租借";
            this.租借ToolStripMenuItem.Click += new System.EventHandler(this.租借ToolStripMenuItem_Click);
            // 
            // 续期ToolStripMenuItem
            // 
            this.续期ToolStripMenuItem.Name = "续期ToolStripMenuItem";
            this.续期ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.续期ToolStripMenuItem.Text = "续期";
            this.续期ToolStripMenuItem.Click += new System.EventHandler(this.续期ToolStripMenuItem_Click);
            // 
            // 归还ToolStripMenuItem
            // 
            this.归还ToolStripMenuItem.Name = "归还ToolStripMenuItem";
            this.归还ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.归还ToolStripMenuItem.Text = "归还";
            this.归还ToolStripMenuItem.Click += new System.EventHandler(this.归还ToolStripMenuItem_Click);
            // 
            // groupUserInfo
            // 
            this.groupUserInfo.Controls.Add(this.btnSave);
            this.groupUserInfo.Controls.Add(this.numAge);
            this.groupUserInfo.Controls.Add(this.txtPhone);
            this.groupUserInfo.Controls.Add(this.txtRegDate);
            this.groupUserInfo.Controls.Add(this.txtEmail);
            this.groupUserInfo.Controls.Add(this.txtAddress);
            this.groupUserInfo.Controls.Add(this.rdoGirl);
            this.groupUserInfo.Controls.Add(this.rdoBoy);
            this.groupUserInfo.Controls.Add(this.txtName);
            this.groupUserInfo.Controls.Add(this.label8);
            this.groupUserInfo.Controls.Add(this.label7);
            this.groupUserInfo.Controls.Add(this.label6);
            this.groupUserInfo.Controls.Add(this.label5);
            this.groupUserInfo.Controls.Add(this.label4);
            this.groupUserInfo.Controls.Add(this.label3);
            this.groupUserInfo.Controls.Add(this.label2);
            this.groupUserInfo.Location = new System.Drawing.Point(12, 148);
            this.groupUserInfo.Name = "groupUserInfo";
            this.groupUserInfo.Size = new System.Drawing.Size(580, 359);
            this.groupUserInfo.TabIndex = 2;
            this.groupUserInfo.TabStop = false;
            this.groupUserInfo.Text = "用户信息";
            // 
            // btnOK2
            // 
            this.btnOK2.Location = new System.Drawing.Point(900, 103);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(54, 23);
            this.btnOK2.TabIndex = 21;
            this.btnOK2.Text = "借  出";
            this.btnOK2.UseVisualStyleBackColor = true;
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(165, 316);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保    存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numAge
            // 
            this.numAge.Location = new System.Drawing.Point(32, 120);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(106, 21);
            this.numAge.TabIndex = 18;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(219, 186);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(334, 21);
            this.txtPhone.TabIndex = 17;
            // 
            // txtRegDate
            // 
            this.txtRegDate.Location = new System.Drawing.Point(219, 119);
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.Size = new System.Drawing.Size(334, 21);
            this.txtRegDate.TabIndex = 16;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(219, 48);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(334, 21);
            this.txtEmail.TabIndex = 15;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(32, 262);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(521, 21);
            this.txtAddress.TabIndex = 14;
            // 
            // rdoGirl
            // 
            this.rdoGirl.AutoSize = true;
            this.rdoGirl.Location = new System.Drawing.Point(102, 187);
            this.rdoGirl.Name = "rdoGirl";
            this.rdoGirl.Size = new System.Drawing.Size(35, 16);
            this.rdoGirl.TabIndex = 13;
            this.rdoGirl.TabStop = true;
            this.rdoGirl.Text = "女";
            this.rdoGirl.UseVisualStyleBackColor = true;
            // 
            // rdoBoy
            // 
            this.rdoBoy.AutoSize = true;
            this.rdoBoy.Location = new System.Drawing.Point(32, 187);
            this.rdoBoy.Name = "rdoBoy";
            this.rdoBoy.Size = new System.Drawing.Size(35, 16);
            this.rdoBoy.TabIndex = 12;
            this.rdoBoy.TabStop = true;
            this.rdoBoy.Text = "男";
            this.rdoBoy.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(32, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(106, 21);
            this.txtName.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(216, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "注册时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(28, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "通讯地址：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(216, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "电子邮件：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(216, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "电话号码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(29, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "年龄：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(28, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名：";
            // 
            // groupBookList
            // 
            this.groupBookList.Controls.Add(this.dgvBooks);
            this.groupBookList.Location = new System.Drawing.Point(598, 148);
            this.groupBookList.Name = "groupBookList";
            this.groupBookList.Size = new System.Drawing.Size(359, 179);
            this.groupBookList.TabIndex = 3;
            this.groupBookList.TabStop = false;
            this.groupBookList.Text = "书籍信息";
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.GridColor = System.Drawing.Color.White;
            this.dgvBooks.Location = new System.Drawing.Point(3, 17);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowTemplate.Height = 23;
            this.dgvBooks.Size = new System.Drawing.Size(353, 159);
            this.dgvBooks.TabIndex = 0;
            this.dgvBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // chkIsReadOnly
            // 
            this.chkIsReadOnly.AutoSize = true;
            this.chkIsReadOnly.Checked = true;
            this.chkIsReadOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsReadOnly.Location = new System.Drawing.Point(510, 105);
            this.chkIsReadOnly.Name = "chkIsReadOnly";
            this.chkIsReadOnly.Size = new System.Drawing.Size(48, 16);
            this.chkIsReadOnly.TabIndex = 26;
            this.chkIsReadOnly.Text = "只读";
            this.chkIsReadOnly.UseVisualStyleBackColor = true;
            this.chkIsReadOnly.CheckedChanged += new System.EventHandler(this.chkIsReadOnly_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(438, 101);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 25);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(181, 103);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(251, 21);
            this.txtUsername.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(66, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "会员卡号：";
            // 
            // txtInfoID
            // 
            this.txtInfoID.LabelText = "输入书籍编号";
            this.txtInfoID.Location = new System.Drawing.Point(598, 104);
            this.txtInfoID.Name = "txtInfoID";
            this.txtInfoID.Size = new System.Drawing.Size(236, 21);
            this.txtInfoID.TabIndex = 27;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(840, 103);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "添  加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupOrders
            // 
            this.groupOrders.Controls.Add(this.dgvOrders);
            this.groupOrders.Location = new System.Drawing.Point(598, 330);
            this.groupOrders.Name = "groupOrders";
            this.groupOrders.Size = new System.Drawing.Size(356, 177);
            this.groupOrders.TabIndex = 29;
            this.groupOrders.TabStop = false;
            this.groupOrders.Text = "未归还图书";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(3, 17);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowTemplate.Height = 23;
            this.dgvOrders.Size = new System.Drawing.Size(350, 157);
            this.dgvOrders.TabIndex = 0;
            // 
            // FrmLeaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 519);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.groupOrders);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtInfoID);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.chkIsReadOnly);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBookList);
            this.Controls.Add(this.groupUserInfo);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLeaseManager";
            this.Text = "租借管理";
            this.Load += new System.EventHandler(this.FrmLeaseManager_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupUserInfo.ResumeLayout(false);
            this.groupUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.groupBookList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.groupOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 租借ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 续期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 归还ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupUserInfo;
        private System.Windows.Forms.GroupBox groupBookList;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnOK2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtRegDate;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.RadioButton rdoGirl;
        private System.Windows.Forms.RadioButton rdoBoy;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIsReadOnly;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private LabeledTextBox.LabelTextBox txtInfoID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupOrders;
        private System.Windows.Forms.DataGridView dgvOrders;
    }
}