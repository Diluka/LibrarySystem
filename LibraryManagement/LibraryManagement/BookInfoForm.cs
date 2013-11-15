using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class BookInfoForm : Form, ISetCAP
    {
        private BookInfo bookInfo;
        private Author author;
        private Press press;
        private Category category;

        public BookInfoForm()
        {
            InitializeComponent();
            ResetControlState();
        }

        private void ResetControlState()
        {
            //txtTitle.Enabled = false;
            //txtAlpha.Enabled = false;
            //txtCategory.Enabled = false;
            //txtAuthor.Enabled = false;
            //txtPress.Enabled = false;
            datePressDate.Enabled = false;
            //txtPrice.Enabled = false;
            //numTotal.Enabled = false;
            //numRemain.Enabled = false;
            //txtISBN.Enabled = false;

            txtTitle.ReadOnly = true;
            txtCategory.ReadOnly = true;
            txtAuthor.ReadOnly = true;
            txtPress.ReadOnly = true;
            txtISBN.ReadOnly = true;

            btnAuthor.Enabled = false;
            btnCategory.Enabled = false;
            btnPress.Enabled = false;
            btnChooseCover.Enabled = false;
            btnClearCover.Enabled = false;
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            btnModify.Enabled = false;

            txtBrief.Enabled = false;
            txtBrief.ReadOnly = true;

            btnClearText.Enabled = false;
        }

        Stream img;
        private void btnChooseCover_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                if (img != null)
                {
                    img.Close();
                }
                img = openFileDialog1.OpenFile();
                picCover.Image = Image.FromStream(img);

            }
            catch (IOException)
            {
                openFileDialog1.Reset();
                if (img != null)
                {
                    img.Dispose();
                    img = null;
                }

            }
        }

        private void btnClearCover_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            picCover.Image.Dispose();
            picCover.Image = null;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ResetControlState();

            txtTitle.Enabled = true;
            txtTitle.ReadOnly = false;

            txtAuthor.Enabled = true;
            txtCategory.Enabled = true;
            txtPress.Enabled = true;

            txtPrice.Enabled = true;
            txtPrice.ReadOnly = false;

            txtISBN.Enabled = true;
            txtISBN.ReadOnly = false;

            datePressDate.Enabled = true;

            btnAuthor.Enabled = true;
            btnCategory.Enabled = true;
            btnPress.Enabled = true;
            btnReset.Enabled = true;
            btnSave.Enabled = true;

            btnChooseCover.Enabled = true;
            btnClearCover.Enabled = true;

            txtBrief.Enabled = true;
            txtBrief.ReadOnly = false;

            btnClearText.Enabled = true;
        }

        private void BookInfoForm_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "添加图书";
                txtBookInfoID.Text = "保存时自动生成";
                btnSave.Enabled = true;

                txtTitle.Enabled = true;
                //txtAuthor.Enabled = true;
                //txtCategory.Enabled = true;
                //txtPress.Enabled = true;
                txtPrice.Enabled = true;

                txtTitle.ReadOnly = false;
                txtPrice.ReadOnly = false;
                txtCategory.ReadOnly = false;
                txtAuthor.ReadOnly = false;
                txtPress.ReadOnly = false;

                btnAuthor.Enabled = true;
                btnCategory.Enabled = true;
                btnPress.Enabled = true;

                picCover.Enabled = true;
                btnChooseCover.Enabled = true;
                btnClearCover.Enabled = true;

                txtBrief.Enabled = true;
                txtBrief.ReadOnly = false;
                btnClearText.Enabled = true;

                btnReset.Enabled = true;

                txtBookInfoID.Enabled = true;

                txtISBN.Enabled = true;
                txtISBN.ReadOnly = false;

                datePressDate.Enabled = true;

            }
            else
            {
                this.Text = "书籍信息";

                try
                {
                    bookInfo = DBHelper.Entities.BookInfoes.Find(this.Tag);

                    txtBookInfoID.Text = bookInfo.BookInfoID.ToString();
                    txtTitle.Text = bookInfo.Title;

                    txtCategory.Text = bookInfo.Category;


                    txtAuthor.Text = bookInfo.Author;


                    txtPress.Text = bookInfo.Press;

                    datePressDate.Value = bookInfo.PublishDate ?? DateTime.Now;
                    txtISBN.Text = bookInfo.ISBN;
                    txtPrice.Text = bookInfo.Price.ToString();

                    if (bookInfo.Cover != null)
                    {
                        picCover.Image = Image.FromStream(new MemoryStream(bookInfo.Cover));
                    }
                    txtBrief.Text = bookInfo.Brief;
                }
                catch (Exception ex)
                {
                    Logger.Log(ex);
                    MessageBox.Show("加载书籍信息时出现错误");
                }

                ResetControlState();
                btnModify.Enabled = true;
            }

        }

        #region IChooseCAP 成员

        public void SetCategory(Category c)
        {
            category = c;
            if (category != null)
            {
                txtCategory.Text = category.CategoryName;
            }
            else
            {
                txtCategory.Text = "";
            }
        }

        public void SetAuthor(Author a)
        {
            author = a;
            if (author != null)
            {
                txtAuthor.Text = author.AuthorName;
            }
            else
            {
                txtAuthor.Text = "";
            }
        }

        public void SetPress(Press p)
        {
            press = p;
            if (press != null)
            {
                txtPress.Text = press.PressName;
            }
            else
            {
                txtPress.Text = "";
            }
        }

        #endregion

        Form frmCatMgr;
        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (frmCatMgr != null && !frmCatMgr.IsDisposed)
            {
                frmCatMgr.ShowDialog(this);
                frmCatMgr.Activate();
            }
            else
            {
                frmCatMgr = new FrmCategoryManager();
                frmCatMgr.ShowDialog(this);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            txtTitle.Text = txtTitle.Text.Trim();
            txtPrice.Text = txtPrice.Text.Trim();
            txtISBN.Text = txtISBN.Text.Trim();

            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("有未填写的必填项", "温馨提示提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int result = 0;

            try
            {
                if (bookInfo == null)
                {
                    bookInfo = new BookInfo();
                    bookInfo.Title = txtTitle.Text;
                    bookInfo.ISBN = txtISBN.Text == "" ? null : txtISBN.Text;
                    bookInfo.Author = txtAuthor.Text == "" ? null : txtAuthor.Text;
                    bookInfo.Press = txtPress.Text == "" ? null : txtPress.Text;
                    bookInfo.Category = txtCategory.Text == "" ? null : txtCategory.Text;
                    bookInfo.PublishDate = datePressDate.Value;
                    if (txtPrice.Text != "")
                    {
                        bookInfo.Price = Convert.ToDecimal(txtPrice.Text);
                    }
                    else
                    {
                        bookInfo.Price = null;
                    }

                    if (img != null)
                    {
                        MemoryStream mem = new MemoryStream();
                        img.Position = 0;
                        img.CopyTo(mem);
                        bookInfo.Cover = mem.GetBuffer();
                    }
                    else
                    {
                        bookInfo.Cover = null;
                    }

                    bookInfo.Brief = txtBrief.Text == "" ? null : txtBrief.Text;


                    DBHelper.Entities.BookInfoes.Add(bookInfo);
                    result = DBHelper.Entities.SaveChanges();

                }
                else
                {
                    bookInfo.Title = txtTitle.Text;
                    bookInfo.ISBN = txtISBN.Text == "" ? null : txtISBN.Text;
                    bookInfo.Author = txtAuthor.Text == "" ? null : txtAuthor.Text;
                    bookInfo.Press = txtPress.Text == "" ? null : txtPress.Text;
                    bookInfo.Category = txtCategory.Text == "" ? null : txtCategory.Text;
                    bookInfo.PublishDate = datePressDate.Value;
                    if (txtPrice.Text != "")
                    {
                        bookInfo.Price = Convert.ToDecimal(txtPrice.Text);
                    }
                    else
                    {
                        bookInfo.Price = null;
                    }

                    if (img != null)
                    {
                        MemoryStream mem = new MemoryStream();
                        img.Position = 0;
                        img.CopyTo(mem);
                        bookInfo.Cover = mem.GetBuffer();
                    }
                    else if (picCover.Image == null)
                    {
                        bookInfo.Cover = null;
                    }

                    bookInfo.Brief = txtBrief.Text == "" ? null : txtBrief.Text;


                    result = DBHelper.Entities.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("保存时出错");
            }


            if (result > 0)
            {
                LoadAll();
                ResetControlState();
                btnModify.Enabled = true;
                img = null;
            }
            else
            {
                MessageBox.Show("没有保存或者保存失败", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }


        private void LoadAll()
        {

            if (bookInfo != null)
            {
                txtBookInfoID.Text = bookInfo.BookInfoID.ToString();
                txtTitle.Text = bookInfo.Title;
                txtISBN.Text = bookInfo.ISBN;
                txtPrice.Text = bookInfo.Price.ToString();
                txtAuthor.Text = bookInfo.Author;
                txtCategory.Text = bookInfo.Category;
                txtPress.Text = bookInfo.Press;
                if (bookInfo.Cover != null)
                {
                    picCover.Image = Image.FromStream(new MemoryStream(bookInfo.Cover));
                }
                else
                {
                    picCover.Image = null;
                }
                txtBrief.Text = bookInfo.Brief;
            }
            else
            {
                //txtBookInfoID.Clear();
                txtTitle.Clear();
                txtISBN.Clear();
                txtPrice.Clear();
                txtAuthor.Clear();
                txtCategory.Clear();
                txtPress.Clear();
                picCover.Image = null;
                txtBrief.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult options = MessageBox.Show("有未保存的修改，确定要保存吗？", "退出提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (options)
                {
                    case DialogResult.Yes:
                        btnSave_Click(sender, e);
                        this.Close();
                        break;
                    case DialogResult.No:
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            txtBrief.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            AuthorsForm af = new AuthorsForm();
            af.ShowDialog(this);
        }

        private void btnPress_Click(object sender, EventArgs e)
        {
            frmBookPressManager fbpm = new frmBookPressManager();
            fbpm.ShowDialog(this);
        }

        private void BookInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                img.Close();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }

    }
}
