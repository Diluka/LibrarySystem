using System;
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
                MessageBox.Show("没有书籍信息", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            IEnumerator<BookInfoListView> ie = DBHelper.Entities.BookInfoListViews.Where(f => f.书籍编号 == bookInfo.BookInfoID).GetEnumerator();
            if (ie.MoveNext())
            {
                BookInfoListView bookInfoListView = ie.Current;

                lblTitle.Text = bookInfoListView.书籍标题;
                lblInfoID.Text = bookInfoListView.书籍编号.ToString();
                lblAuthor.Text = bookInfoListView.作者 ?? "[未指定]";
                lblCategory.Text = bookInfoListView.类别 ?? "[未指定]";
                lblPress.Text = bookInfoListView.出版社 ?? "[未指定]";
                lblAll.Text = bookInfoListView.总库存 == null ? "0" : bookInfoListView.总库存.ToString();
                lblNow.Text = bookInfoListView.现库存 == null ? "0" : bookInfoListView.现库存.ToString();
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
                MessageBox.Show("添加失败", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {

            books = DBHelper.Entities.Books.Where(f => f.BookInfoID == bookInfo.BookInfoID);

            dgvBooks.DataSource = books.ToArray<Book>();
            dgvBooks.Columns["Remark"].Visible = false;
            dgvBooks.Columns["Records"].Visible = false;
            dgvBooks.Columns["BookInfo"].Visible = false;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的书本", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            int bid = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookID"].Value);

            if (MessageBox.Show(string.Format("确定要删除编号为：{0}的书本吗？", bid), "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
                MessageBox.Show("删除失败，请确定书本不处于借出状态", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 备注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book b = dgvBooks.CurrentRow.DataBoundItem as Book;
            Form form = new RemarkForm();
            form.Tag = b;
            form.Text = string.Format("《{0}》的备注信息", b.BookInfo.Title);
            form.ShowDialog();
        }
    }
}
