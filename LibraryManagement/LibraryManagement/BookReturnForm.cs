using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryDB;

namespace LibraryManagement
{
    public partial class BookReturnForm : Form
    {
        public BookReturnForm()
        {
            InitializeComponent();
        }

        private void BookReturnForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            txtBookID.Text = txtBookID.Text.Trim();

            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                MessageBox.Show("请输入书本编号");
                return;
            }
            Record record = null;
            try
            {
                DBHelper.conn.Open();
                record = LibraryHelper.ReturnBook(Convert.ToInt64(txtBookID.Text), DBHelper.conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }

            if (record == null)
            {
                MessageBox.Show("失败");
            }
        }
        User user;
        DataSet ds = new DataSet();
        private void btnOK_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            else
            {
                try
                {
                    DBHelper.conn.Open();
                    user = User.GetUserByName(txtUsername.Text, DBHelper.conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.conn.Close();
                }
            }
            ShowOrders();
        }

        private void ShowOrders()
        {
            if (user != null)
                using (SqlDataAdapter da = new SqlDataAdapter("select * from orderview where 用户ID=" + user.Uid, DBHelper.conn))
                {
                    if (ds.Tables["orders"] != null)
                    {
                        ds.Tables["orders"].Clear();
                    }
                    da.Fill(ds, "orders");
                    dgvOrders.DataSource = ds.Tables["orders"];
                    dgvOrders.Columns["用户ID"].Visible = false;
                }
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null && user != null)
            {
                long bid = (long)dgvOrders.CurrentRow.Cells["书本编号"].Value;
                Record record = null;
                try
                {
                    DBHelper.conn.Open();
                    record = LibraryHelper.ReturnBook(bid, DBHelper.conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.conn.Close();
                }

                if (record == null)
                {
                    MessageBox.Show("失败");
                }
                else
                {
                    ShowOrders();
                }
            }
            else
            {
                MessageBox.Show("请选择");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = dgvOrders.CurrentRow == null;
        }
    }
}
