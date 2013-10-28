using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryDB;

namespace LibraryManagement
{
    public partial class BookInfoForm : Form, ISetCAP
    {
        private BookInfo bookInfo;
        private Author author;
        private Press press;
        private Category category;
        private Cover cover;
        private BookBrief bookBrief;

        public BookInfoForm()
        {
            InitializeComponent();
            ResetControlState();
        }

        private void ResetControlState()
        {
            txtTitle.Enabled = false;
            txtAlpha.Enabled = false;
            txtCategory.Enabled = false;
            txtAuthor.Enabled = false;
            txtPress.Enabled = false;
            datePressDate.Enabled = false;
            txtPrice.Enabled = false;
            numTotal.Enabled = false;
            numRemain.Enabled = false;
            txtISBN.Enabled = false;

            txtTitle.ReadOnly = true;
            txtAlpha.ReadOnly = true;
            txtCategory.ReadOnly = true;
            txtAuthor.ReadOnly = true;
            txtPress.ReadOnly = true;
            numTotal.ReadOnly = true;
            numRemain.ReadOnly = true;
            txtISBN.ReadOnly = true;

            btnAuthor.Enabled = false;
            btnCategory.Enabled = false;
            btnPress.Enabled = false;
            btnChooseCover.Enabled = false;
            btnClearCover.Enabled = false;
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            btnModify.Enabled = false;

            btnUnlock.Enabled = false;
            btnUnlock.Visible = false;

            txtBrief.Enabled = false;
            txtBrief.ReadOnly = true;

            btnClearText.Enabled = false;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("修改锁定的数据将无法保证数据库的完整性！是否继续？", "*警告*", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                UnlockNumbers();
            }
        }

        private void UnlockNumbers()
        {
            numTotal.Enabled = true;
            numTotal.ReadOnly = false;
            numRemain.Enabled = true;
            numRemain.ReadOnly = false;
        }

        private void btnChooseCover_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Stream img = openFileDialog1.OpenFile();
            if (img != null)
            {
                picCover.Image = Image.FromStream(img);
            }
        }

        private void btnClearCover_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            picCover.Image.Dispose();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ResetControlState();

            txtTitle.Enabled = true;
            txtTitle.ReadOnly = false;

            txtAlpha.Enabled = true;
            txtAlpha.ReadOnly = false;

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

            btnUnlock.Visible = true;
            btnUnlock.Enabled = true;

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
                txtAlpha.Enabled = true;
                //txtAuthor.Enabled = true;
                //txtCategory.Enabled = true;
                //txtPress.Enabled = true;
                txtPrice.Enabled = true;

                txtTitle.ReadOnly = false;
                txtAlpha.ReadOnly = false;
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

                btnUnlock.Enabled = true;
            }
            else
            {
                this.Text = "书籍信息";

                long bid = Convert.ToInt64(this.Tag);
                try
                {
                    DBHelper.conn.Open();
                    bookInfo = BookInfo.GetBookInfoByID(bid, DBHelper.conn);
                    author = Author.GetAuthorByID(bookInfo.AuthorID ?? 0, DBHelper.conn);
                    category = Category.GetCategoryByID(bookInfo.CatID ?? 0, DBHelper.conn);
                    press = Press.GetPressByID(bookInfo.PressID ?? 0, DBHelper.conn);
                    cover = Cover.GetCoverByID(bookInfo.InfoID, DBHelper.conn);
                    bookBrief = BookBrief.GetBookBriefByID(bookInfo.InfoID, DBHelper.conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.conn.Close();
                }

                txtBookInfoID.Text = bookInfo.InfoID.ToString();
                txtTitle.Text = bookInfo.Title;
                txtAlpha.Text = bookInfo.Alphabet.ToString();
                if (category != null)
                {
                    txtCategory.Text = category.CategoryName;
                }
                if (author != null)
                {
                    txtAuthor.Text = author.AuthorName;
                }
                if (press != null)
                {
                    txtPress.Text = press.PressName;
                }
                datePressDate.Value = bookInfo.PressDate ?? DateTime.Now;
                txtISBN.Text = bookInfo.ISBN;
                txtPrice.Text = bookInfo.Price.ToString();
                numTotal.Value = bookInfo.Total;
                numRemain.Value = bookInfo.Remain;

                if (cover != null)
                {
                    picCover.Image = cover.CoverImage;
                }
                if (bookBrief != null)
                {
                    txtBrief.Text = bookBrief.BriefText;
                }

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
        }

        public void SetAuthor(Author a)
        {
            author = a;
            if (author != null)
            {
                txtAuthor.Text = author.AuthorName;
            }
        }

        public void SetPress(Press p)
        {
            press = p;
            if (press != null)
            {
                txtPress.Text = press.PressName;
            }
        }

        #endregion

        Form frmCatMgr;
        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (frmCatMgr != null && !frmCatMgr.IsDisposed)
            {
                frmCatMgr.Show(this);
                frmCatMgr.Activate();
            }
            else
            {
                frmCatMgr = new FrmCategoryManager();
                frmCatMgr.Show(this);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtTitle.Text = txtTitle.Text.Trim();
            txtPrice.Text = txtPrice.Text.Trim();
            txtAlpha.Text = txtAlpha.Text.Trim();
            txtISBN.Text = txtISBN.Text.Trim();

            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtAlpha.Text))
            {
                MessageBox.Show("有未填写的必填项", "提示");
                return;
            }

            int result = 0;

            try
            {
                if (bookInfo == null)
                {
                    bookInfo = new BookInfo(
                       category == null ? null : (int?)category.CatID,
                       txtTitle.Text,
                       txtAlpha.Text[0],
                       txtISBN.Text,
                       author == null ? null : (int?)author.AuthorID,
                       press == null ? null : (int?)press.PressID,
                       datePressDate.Value,
                       string.IsNullOrEmpty(txtPrice.Text) ? null : (decimal?)Convert.ToDecimal(txtPrice.Text));



                    DBHelper.conn.Open();
                    result += ((IDBOperate)bookInfo).Insert(DBHelper.conn);
                    if (txtBrief.Text != "")
                    {
                        bookBrief = new BookBrief(bookInfo.InfoID, txtBrief.Text);
                        result += ((IDBOperate)bookBrief).Insert(DBHelper.conn);
                    }
                    if (picCover.Image != null)
                    {
                        cover = new Cover(bookInfo.InfoID, openFileDialog1.OpenFile());
                        result += ((IDBOperate)cover).Insert(DBHelper.conn);
                    }
                }
                else
                {
                    bookInfo.Title = txtTitle.Text;
                    bookInfo.Alphabet = txtAlpha.Text[0];
                    if (category != null)
                    {
                        bookInfo.CatID = category.CatID;
                    }
                    if (author != null)
                    {
                        bookInfo.AuthorID = author.AuthorID;
                    }
                    if (press != null)
                    {
                        bookInfo.PressID = press.PressID;
                    }
                    bookInfo.PressDate = datePressDate.Value;
                    bookInfo.Price = Convert.ToDecimal(txtPrice.Text);
                    bookInfo.ISBN = txtISBN.Text;
                    bookInfo.Total = (int)numTotal.Value;
                    bookInfo.Remain = (int)numRemain.Value;


                    DBHelper.conn.Open();
                    result += ((IDBOperate)bookInfo).Update(DBHelper.conn);

                    if (bookBrief != null)
                    {
                        if (txtBrief.Text != "")
                        {
                            bookBrief.BriefText = txtBrief.Text;
                            result += ((IDBOperate)bookBrief).Update(DBHelper.conn);
                        }
                        else
                        {
                            result += ((IDBOperate)bookBrief).Delete(DBHelper.conn);
                        }
                    }
                    else
                    {
                        if (txtBrief.Text != "")
                        {
                            bookBrief = new BookBrief(bookInfo.InfoID, txtBrief.Text);
                            result += ((IDBOperate)bookBrief).Insert(DBHelper.conn);
                        }
                    }

                    if (cover != null)
                    {
                        if (picCover.Image != null)
                        {
                            if (openFileDialog1.OpenFile() != null)
                            {
                                cover.ImageStream = openFileDialog1.OpenFile();
                                result += ((IDBOperate)cover).Update(DBHelper.conn);
                            }
                        }
                        else
                        {
                            result += ((IDBOperate)cover).Delete(DBHelper.conn);
                        }
                    }
                    else
                    {
                        if (picCover.Image != null)
                        {
                            cover = new Cover(bookInfo.InfoID, openFileDialog1.OpenFile());
                            result += ((IDBOperate)cover).Insert(DBHelper.conn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }

            if (result > 0)
            {
                LoadAll();
                ResetControlState();
                btnModify.Enabled = true;
            }
            else
            {
                MessageBox.Show("没有保存或者保存失败", "保存提示");
            }
        }

        private void LoadAll()
        {
            if (bookInfo != null)
            {
                txtBookInfoID.Text = bookInfo.InfoID.ToString();
                txtTitle.Text = bookInfo.Title;
                txtAlpha.Text = bookInfo.Alphabet.ToString();
                txtISBN.Text = bookInfo.ISBN;
                txtPrice.Text = bookInfo.Price.ToString();

                numTotal.Value = bookInfo.Total;
                numRemain.Value = bookInfo.Remain;


                try
                {
                    DBHelper.conn.Open();

                    if (category == null && bookInfo.CatID != null)
                    {
                        category = Category.GetCategoryByID((int)bookInfo.CatID, DBHelper.conn);
                    }
                    if (author == null && bookInfo.AuthorID != null)
                    {
                        author = Author.GetAuthorByID((int)bookInfo.AuthorID, DBHelper.conn);
                    }
                    if (press == null && bookInfo.PressID != null)
                    {
                        press = Press.GetPressByID((int)bookInfo.PressID, DBHelper.conn);
                    }
                    if (cover == null)
                    {
                        cover = Cover.GetCoverByID(bookInfo.InfoID, DBHelper.conn);
                    }
                    if (bookBrief == null)
                    {
                        bookBrief = BookBrief.GetBookBriefByID(bookInfo.InfoID, DBHelper.conn);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.conn.Close();
                }

                if (category != null)
                {
                    txtCategory.Text = category.CategoryName;
                }
                if (author != null)
                {
                    txtAuthor.Text = author.AuthorName;
                }
                if (press != null)
                {
                    txtPress.Text = press.PressName;
                }
                if (cover != null)
                {
                    picCover.Image = cover.CoverImage;
                }
                if (bookBrief != null)
                {
                    txtBrief.Text = bookBrief.BriefText;
                }
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
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            txtBrief.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadAll();
        }
    }
}
