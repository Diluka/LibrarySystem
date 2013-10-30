using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryDB;

namespace LibraryManagement
{
    public partial class BookForm : Form
    {
        public BookForm()
        {
            InitializeComponent();
        }

        private BookInfo bookInfo;
        private Author author;
        private Press press;
        private Category category;
        private List<Book> books;

        private void BookForm_Load(object sender, EventArgs e)
        {
            bookInfo = this.Tag as BookInfo;

            if (bookInfo == null)
            {
                MessageBox.Show("没有书籍信息");
                this.Close();
            }

            try
            {
                DBHelper.conn.Open();
                books = Book.GetBooksByInfoID(bookInfo.InfoID, DBHelper.conn);
                category = Category.GetCategoryByID(bookInfo.CatID ?? 0, DBHelper.conn);
                author = Author.GetAuthorByID(bookInfo.AuthorID ?? 0, DBHelper.conn);
                press = Press.GetPressByID(bookInfo.PressID ?? 0, DBHelper.conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }

            lblTitle.Text = bookInfo.Title;
            lblInfoID.Text = bookInfo.InfoID.ToString();
            lblAuthor.Text = author.AuthorName ?? "[未指定]";
            lblCategory.Text = category.CategoryName ?? "[未指定]";
            lblPress.Text = press.PressName ?? "[未指定]";

            dgvBooks.DataSource = books;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Book b = new Book(bookInfo.InfoID);
            int result = 0;
            try
            {
                DBHelper.conn.Open();
                result = ((IDBOperate)b).Insert(DBHelper.conn);
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

            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的书本");
                return;
            }

            long bid = Convert.ToInt64(dgvBooks.SelectedRows[0].Cells["书本编号"].Value);

            if (MessageBox.Show(string.Format("确定要删除编号为：{0}的书本吗？", bid), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int result = 0;
            try
            {
                DBHelper.conn.Open();
                result = Book.DelBookByID(bid, DBHelper.conn);
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

            }
            else
            {
                MessageBox.Show("删除失败，请确定书本不处于借出状态");
            }
        }
    }
}
