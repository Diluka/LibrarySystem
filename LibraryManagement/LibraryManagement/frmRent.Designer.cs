namespace LibraryManagement
{
    partial class FrmRent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRent));
            this.groupOrders = new System.Windows.Forms.GroupBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBookID = new LabeledTextBox.LabelTextBox();
            this.btnOK2 = new System.Windows.Forms.Button();
            this.chkIsReadOnly = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBookList = new System.Windows.Forms.GroupBox();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.groupUserInfo = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.rdoGirl = new System.Windows.Forms.RadioButton();
            this.rdoBoy = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.groupBookList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.groupUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOrders
            // 
            this.groupOrders.Controls.Add(this.dgvOrders);
            this.groupOrders.Location = new System.Drawing.Point(546, 242);
            this.groupOrders.Name = "groupOrders";
            this.groupOrders.Size = new System.Drawing.Size(420, 177);
            this.groupOrders.TabIndex = 39;
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
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(414, 157);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(788, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "添  加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBookID
            // 
            this.txtBookID.LabelText = "输入书本编号";
            this.txtBookID.Location = new System.Drawing.Point(546, 16);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(236, 21);
            this.txtBookID.TabIndex = 37;
            // 
            // btnOK2
            // 
            this.btnOK2.Location = new System.Drawing.Point(848, 15);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(54, 23);
            this.btnOK2.TabIndex = 32;
            this.btnOK2.Text = "借  出";
            this.btnOK2.UseVisualStyleBackColor = true;
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // chkIsReadOnly
            // 
            this.chkIsReadOnly.AutoSize = true;
            this.chkIsReadOnly.Checked = true;
            this.chkIsReadOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsReadOnly.Location = new System.Drawing.Point(485, 20);
            this.chkIsReadOnly.Name = "chkIsReadOnly";
            this.chkIsReadOnly.Size = new System.Drawing.Size(48, 16);
            this.chkIsReadOnly.TabIndex = 36;
            this.chkIsReadOnly.Text = "只读";
            this.chkIsReadOnly.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(413, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 25);
            this.btnOK.TabIndex = 35;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(156, 18);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(251, 21);
            this.txtUsername.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(41, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "会员卡号：";
            // 
            // groupBookList
            // 
            this.groupBookList.Controls.Add(this.dgvBooks);
            this.groupBookList.Location = new System.Drawing.Point(546, 60);
            this.groupBookList.Name = "groupBookList";
            this.groupBookList.Size = new System.Drawing.Size(420, 179);
            this.groupBookList.TabIndex = 31;
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
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(414, 159);
            this.dgvBooks.TabIndex = 0;
            this.dgvBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellContentClick);
            // 
            // groupUserInfo
            // 
            this.groupUserInfo.Controls.Add(this.btnSave);
            this.groupUserInfo.Controls.Add(this.numAge);
            this.groupUserInfo.Controls.Add(this.txtPhone);
            this.groupUserInfo.Controls.Add(this.txtEmail);
            this.groupUserInfo.Controls.Add(this.txtAddress);
            this.groupUserInfo.Controls.Add(this.rdoGirl);
            this.groupUserInfo.Controls.Add(this.rdoBoy);
            this.groupUserInfo.Controls.Add(this.txtName);
            this.groupUserInfo.Controls.Add(this.label7);
            this.groupUserInfo.Controls.Add(this.label6);
            this.groupUserInfo.Controls.Add(this.label5);
            this.groupUserInfo.Controls.Add(this.label4);
            this.groupUserInfo.Controls.Add(this.label3);
            this.groupUserInfo.Controls.Add(this.label2);
            this.groupUserInfo.Location = new System.Drawing.Point(14, 60);
            this.groupUserInfo.Name = "groupUserInfo";
            this.groupUserInfo.Size = new System.Drawing.Size(517, 359);
            this.groupUserInfo.TabIndex = 30;
            this.groupUserInfo.TabStop = false;
            this.groupUserInfo.Text = "用户信息";
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
            this.numAge.Location = new System.Drawing.Point(32, 145);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(106, 21);
            this.numAge.TabIndex = 18;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(219, 117);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(269, 21);
            this.txtPhone.TabIndex = 17;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(219, 48);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(269, 21);
            this.txtEmail.TabIndex = 15;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(220, 192);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(268, 102);
            this.txtAddress.TabIndex = 14;
            // 
            // rdoGirl
            // 
            this.rdoGirl.AutoSize = true;
            this.rdoGirl.Location = new System.Drawing.Point(102, 235);
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
            this.rdoBoy.Location = new System.Drawing.Point(32, 235);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(216, 164);
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
            this.label5.Location = new System.Drawing.Point(216, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "电话号码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(29, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 119);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(912, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "清  空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupOrders);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.chkIsReadOnly);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBookList);
            this.Controls.Add(this.groupUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmRent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "书籍借出";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRent_FormClosed);
            this.Load += new System.EventHandler(this.frmRent_Load);
            this.groupOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.groupBookList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.groupUserInfo.ResumeLayout(false);
            this.groupUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOrders;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnAdd;
        private LabeledTextBox.LabelTextBox txtBookID;
        private System.Windows.Forms.Button btnOK2;
        private System.Windows.Forms.CheckBox chkIsReadOnly;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBookList;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.GroupBox groupUserInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.RadioButton rdoGirl;
        private System.Windows.Forms.RadioButton rdoBoy;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}