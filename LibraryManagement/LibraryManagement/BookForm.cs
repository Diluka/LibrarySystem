﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class BookForm : Form
    {
        public BookForm()
        {
            InitializeComponent();
        }

        private BookInfo bookInfo;
        private IQueryable<Book> books;

        private void BookForm_Load(object sender, EventArgs e)
        {
            bookInfo = this.Tag as BookInfo;

            if (bookInfo == null)
            {
                MessageBox.Show("没有书籍信息", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            try
            {
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadInfo();

            dgvBooks.Columns["BookInfoID"].Visible = false;
            dgvBooks.Columns["BookID"].HeaderText = "书本编号";
            dgvBooks.Columns["IsRent"].HeaderText = "已借出";
        }

        private void LoadInfo()
        {
            IEnumerator<BookView> ie = DBHelper.Entities.BookViews.Where(f => f.书籍编号 == bookInfo.BookInfoID).GetEnumerator();
            if (ie.MoveNext())
            {
                BookView bookView = ie.Current;

                lblTitle.Text = bookView.书籍标题;
                lblInfoID.Text = bookView.书籍编号.ToString();
                lblAuthor.Text = bookView.作者 ?? "[未指定]";
                lblCategory.Text = bookView.类别 ?? "[未指定]";
                lblPress.Text = bookView.出版社 ?? "[未指定]";
                lblAll.Text = bookView.总库存.ToString();
                lblNow.Text = bookView.现库存.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BookInfoID = bookInfo.BookInfoID;
            int result = 0;
            try
            {

                DBHelper.Entities.Books.Add(b);
                result = DBHelper.Entities.SaveChanges();
                books = DBHelper.Entities.Books.Where(f => f.BookInfoID == bookInfo.BookInfoID);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (result > 0)
            {
                LoadBooks();
                LoadInfo();
            }
            else
            {
                MessageBox.Show("添加失败", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {

            books = DBHelper.Entities.Books.Where(f => f.BookInfoID == bookInfo.BookInfoID);

            dgvBooks.DataSource = books;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的书本", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            int bid = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookID"].Value);

            if (MessageBox.Show(string.Format("确定要删除编号为：{0}的书本吗？", bid), "迅邦温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int result = 0;
            try
            {

                Book b = DBHelper.Entities.Books.Find(bid);
                DBHelper.Entities.Books.Remove(b);
                result = DBHelper.Entities.SaveChanges();

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
                LoadBooks();
                LoadInfo();
            }
            else
            {
                MessageBox.Show("删除失败，请确定书本不处于借出状态", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
