namespace LibraryManagement
{
    partial class BookInfoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBookInfoID = new System.Windows.Forms.TextBox();
            this.datePressDate = new System.Windows.Forms.DateTimePicker();
            this.numTotal = new System.Windows.Forms.NumericUpDown();
            this.numRemain = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseCover = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnAuthor = new System.Windows.Forms.Button();
            this.btnPress = new System.Windows.Forms.Button();
            this.btnClearCover = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClearText = new System.Windows.Forms.Button();
            this.txtBrief = new System.Windows.Forms.RichTextBox();
            this.txtISBN = new LabeledTextBox.LabelTextBox();
            this.txtAlpha = new LabeledTextBox.LabelTextBox();
            this.txtPress = new LabeledTextBox.LabelTextBox();
            this.txtAuthor = new LabeledTextBox.LabelTextBox();
            this.txtCategory = new LabeledTextBox.LabelTextBox();
            this.txtPrice = new LabeledTextBox.LabelTextBox();
            this.txtTitle = new LabeledTextBox.LabelTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRemain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "书籍编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "标    题";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "分    类";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "作    者";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "出 版 社";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "出版日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "书籍定价";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "馆藏总数";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 356);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "现 库 存";
            // 
            // txtBookInfoID
            // 
            this.txtBookInfoID.Location = new System.Drawing.Point(88, 26);
            this.txtBookInfoID.Name = "txtBookInfoID";
            this.txtBookInfoID.ReadOnly = true;
            this.txtBookInfoID.Size = new System.Drawing.Size(200, 21);
            this.txtBookInfoID.TabIndex = 9;
            // 
            // datePressDate
            // 
            this.datePressDate.Location = new System.Drawing.Point(87, 250);
            this.datePressDate.Name = "datePressDate";
            this.datePressDate.Size = new System.Drawing.Size(200, 21);
            this.datePressDate.TabIndex = 12;
            // 
            // numTotal
            // 
            this.numTotal.Enabled = false;
            this.numTotal.Location = new System.Drawing.Point(88, 318);
            this.numTotal.Name = "numTotal";
            this.numTotal.ReadOnly = true;
            this.numTotal.Size = new System.Drawing.Size(200, 21);
            this.numTotal.TabIndex = 16;
            // 
            // numRemain
            // 
            this.numRemain.Enabled = false;
            this.numRemain.Location = new System.Drawing.Point(88, 352);
            this.numRemain.Name = "numRemain";
            this.numRemain.ReadOnly = true;
            this.numRemain.Size = new System.Drawing.Size(200, 21);
            this.numRemain.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "书籍封面";
            // 
            // picCover
            // 
            this.picCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCover.Location = new System.Drawing.Point(322, 49);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(156, 209);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCover.TabIndex = 19;
            this.picCover.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "位图文件(*.bmp)|*.bmp|GIF|*.gif|PNG|*.png|JPEG|*.jpeg;*jpe;*.jpg;*.jifi|所有图片文件|*.bmp;" +
    "*.gif;*.png;*.jpeg;*jpe;*.jpg;*.jifi|所有文件|*.*";
            this.openFileDialog1.Title = "选择封面图片";
            // 
            // btnChooseCover
            // 
            this.btnChooseCover.Enabled = false;
            this.btnChooseCover.Location = new System.Drawing.Point(322, 271);
            this.btnChooseCover.Name = "btnChooseCover";
            this.btnChooseCover.Size = new System.Drawing.Size(75, 23);
            this.btnChooseCover.TabIndex = 20;
            this.btnChooseCover.Text = "选择封面";
            this.btnChooseCover.UseVisualStyleBackColor = true;
            this.btnChooseCover.Click += new System.EventHandler(this.btnChooseCover_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(161, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保    存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(242, 401);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 22;
            this.btnModify.Text = "修    改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(581, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "关    闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Enabled = false;
            this.btnCategory.Location = new System.Drawing.Point(213, 147);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(75, 23);
            this.btnCategory.TabIndex = 28;
            this.btnCategory.Text = "查询分类";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnAuthor
            // 
            this.btnAuthor.Enabled = false;
            this.btnAuthor.Location = new System.Drawing.Point(213, 181);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnAuthor.TabIndex = 29;
            this.btnAuthor.Text = "查询作者";
            this.btnAuthor.UseVisualStyleBackColor = true;
            // 
            // btnPress
            // 
            this.btnPress.Enabled = false;
            this.btnPress.Location = new System.Drawing.Point(213, 215);
            this.btnPress.Name = "btnPress";
            this.btnPress.Size = new System.Drawing.Size(75, 23);
            this.btnPress.TabIndex = 30;
            this.btnPress.Text = "查询出版社";
            this.btnPress.UseVisualStyleBackColor = true;
            // 
            // btnClearCover
            // 
            this.btnClearCover.Enabled = false;
            this.btnClearCover.Location = new System.Drawing.Point(403, 271);
            this.btnClearCover.Name = "btnClearCover";
            this.btnClearCover.Size = new System.Drawing.Size(75, 23);
            this.btnClearCover.TabIndex = 31;
            this.btnClearCover.Text = "清除封面";
            this.btnClearCover.UseVisualStyleBackColor = true;
            this.btnClearCover.Click += new System.EventHandler(this.btnClearCover_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(323, 401);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "重    置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Enabled = false;
            this.btnUnlock.ForeColor = System.Drawing.Color.Red;
            this.btnUnlock.Location = new System.Drawing.Point(294, 351);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(38, 23);
            this.btnUnlock.TabIndex = 33;
            this.btnUnlock.Text = "解锁";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Visible = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 34;
            this.label11.Text = "首 字 母";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "I S B N";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(507, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 38;
            this.label13.Text = "书籍简介";
            // 
            // btnClearText
            // 
            this.btnClearText.Enabled = false;
            this.btnClearText.Location = new System.Drawing.Point(729, 380);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(75, 23);
            this.btnClearText.TabIndex = 40;
            this.btnClearText.Text = "清除文字";
            this.btnClearText.UseVisualStyleBackColor = true;
            this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
            // 
            // txtBrief
            // 
            this.txtBrief.BackColor = System.Drawing.Color.White;
            this.txtBrief.Location = new System.Drawing.Point(509, 49);
            this.txtBrief.Name = "txtBrief";
            this.txtBrief.ReadOnly = true;
            this.txtBrief.Size = new System.Drawing.Size(295, 319);
            this.txtBrief.TabIndex = 41;
            this.txtBrief.Text = "";
            // 
            // txtISBN
            // 
            this.txtISBN.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtISBN.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtISBN.LabelText = "选填";
            this.txtISBN.Location = new System.Drawing.Point(88, 122);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.ReadOnly = true;
            this.txtISBN.Size = new System.Drawing.Size(199, 21);
            this.txtISBN.TabIndex = 37;
            this.txtISBN.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // txtAlpha
            // 
            this.txtAlpha.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtAlpha.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtAlpha.LabelText = "必填";
            this.txtAlpha.Location = new System.Drawing.Point(88, 94);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.ReadOnly = true;
            this.txtAlpha.Size = new System.Drawing.Size(199, 21);
            this.txtAlpha.TabIndex = 35;
            this.txtAlpha.TextColor = System.Drawing.SystemColors.ControlText;
            this.txtAlpha.TextChanged += new System.EventHandler(this.txtAlpha_TextChanged);
            // 
            // txtPress
            // 
            this.txtPress.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtPress.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtPress.LabelText = "选填";
            this.txtPress.Location = new System.Drawing.Point(88, 216);
            this.txtPress.Name = "txtPress";
            this.txtPress.ReadOnly = true;
            this.txtPress.Size = new System.Drawing.Size(119, 21);
            this.txtPress.TabIndex = 27;
            this.txtPress.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // txtAuthor
            // 
            this.txtAuthor.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtAuthor.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtAuthor.LabelText = "选填";
            this.txtAuthor.Location = new System.Drawing.Point(88, 182);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(119, 21);
            this.txtAuthor.TabIndex = 26;
            this.txtAuthor.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // txtCategory
            // 
            this.txtCategory.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtCategory.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtCategory.LabelText = "选填";
            this.txtCategory.Location = new System.Drawing.Point(88, 148);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(119, 21);
            this.txtCategory.TabIndex = 25;
            this.txtCategory.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // txtPrice
            // 
            this.txtPrice.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtPrice.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtPrice.LabelText = "选填";
            this.txtPrice.Location = new System.Drawing.Point(88, 284);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(199, 21);
            this.txtPrice.TabIndex = 24;
            this.txtPrice.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // txtTitle
            // 
            this.txtTitle.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txtTitle.LabelColor = System.Drawing.SystemColors.ControlDark;
            this.txtTitle.LabelText = "必填";
            this.txtTitle.Location = new System.Drawing.Point(88, 60);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(200, 21);
            this.txtTitle.TabIndex = 10;
            this.txtTitle.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // BookInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 449);
            this.Controls.Add(this.txtBrief);
            this.Controls.Add(this.btnClearText);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAlpha);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClearCover);
            this.Controls.Add(this.btnPress);
            this.Controls.Add(this.btnAuthor);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.txtPress);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChooseCover);
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numRemain);
            this.Controls.Add(this.numTotal);
            this.Controls.Add(this.datePressDate);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtBookInfoID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BookInfoForm";
            this.Text = "BookInfoForm";
            this.Load += new System.EventHandler(this.BookInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRemain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBookInfoID;
        private LabeledTextBox.LabelTextBox txtTitle;
        private System.Windows.Forms.DateTimePicker datePressDate;
        private System.Windows.Forms.NumericUpDown numTotal;
        private System.Windows.Forms.NumericUpDown numRemain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnChooseCover;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnClose;
        private LabeledTextBox.LabelTextBox txtPrice;
        private LabeledTextBox.LabelTextBox txtCategory;
        private LabeledTextBox.LabelTextBox txtAuthor;
        private LabeledTextBox.LabelTextBox txtPress;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnAuthor;
        private System.Windows.Forms.Button btnPress;
        private System.Windows.Forms.Button btnClearCover;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Label label11;
        private LabeledTextBox.LabelTextBox txtAlpha;
        private System.Windows.Forms.Label label12;
        private LabeledTextBox.LabelTextBox txtISBN;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClearText;
        private System.Windows.Forms.RichTextBox txtBrief;
    }
}