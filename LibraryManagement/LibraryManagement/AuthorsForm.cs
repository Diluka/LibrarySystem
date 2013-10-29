using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryDB;
namespace LibraryManagement
{
    public partial class AuthorsForm : Form
    {
        public AuthorsForm()
        {
            InitializeComponent();
        }
        List<Author> authors;

        private void AuthorsForm_Load(object sender, EventArgs e)
        {
            try
            {
                DBHelper.conn.Open();
                authors = Author.GetAllAuthors(DBHelper.conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }

            listAuthors.DataSource = authors;
            listAuthors.DisplayMember = "AuthorName";
            listAuthors.ValueMember = "AuthorID";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtSearchString.Text = txtSearchString.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearchString.Text))
            {
                listAuthors.SelectedIndex = listAuthors.FindString(txtSearchString.Text);
                ISetCAP target = this.Owner as ISetCAP;
                if (target != null)
                {
                    target.SetAuthor(listAuthors.SelectedItem as Author);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSearchString.Text = txtSearchString.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearchString.Text) && listAuthors.FindStringExact(txtSearchString.Text) == -1)
            {
                DialogResult result = MessageBox.Show(string.Format("是否添加作者“{0}”？", txtSearchString.Text), "添加提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    int res = 0;
                    try
                    {
                        DBHelper.conn.Open();
                        Author a = new Author(txtSearchString.Text);
                        res = ((IDBOperate)a).Insert(DBHelper.conn);
                        authors = Author.GetAllAuthors(DBHelper.conn);
                        listAuthors.DataSource = authors;
                        listAuthors.EndUpdate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DBHelper.conn.Close();
                    }

                    if (res > 0)
                    {
                        listAuthors.SelectedIndex = listAuthors.FindStringExact(txtSearchString.Text);

                        ISetCAP target = this.Owner as ISetCAP;
                        if (target != null)
                        {
                            target.SetAuthor(listAuthors.SelectedItem as Author);
                        }
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listAuthors.SelectedIndex = -1;
            ISetCAP target = this.Owner as ISetCAP;
            if (target != null)
            {
                target.SetAuthor(null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Author a = listAuthors.SelectedItem as Author;

            if (a != null)
            {
                DialogResult result = MessageBox.Show(string.Format("是否要删除作者“{0}”？", a.AuthorName), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int res = 0;
                    try
                    {
                        DBHelper.conn.Open();
                        res = ((IDBOperate)a).Delete(DBHelper.conn);
                        authors = Author.GetAllAuthors(DBHelper.conn);
                        listAuthors.DataSource = authors;
                        listAuthors.EndUpdate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DBHelper.conn.Close();
                    }

                    if (res > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
        }

        private void listAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ISetCAP target = this.Owner as ISetCAP;
            if (target != null)
            {
                target.SetAuthor(listAuthors.SelectedItem as Author);
            }
        }
    }
}
