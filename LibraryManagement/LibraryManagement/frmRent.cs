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
    public partial class FrmRent : Form
    {
        public FrmRent()
        {
            InitializeComponent();
        }
        User user;
        UserInfo userInfo;
        UserGroupInfo userGroupInfo;
        private List<Order> orders;
        private void btnOK_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtUsername.Text.Trim();
            user = null;
            userInfo = null;
            groupUserInfo = null;
            chkIsReadOnly.Checked = true;
            orders = null;

            try
            {
                DBHelper.conn.Open();
                user = User.GetUserByName(txtUsername.Text.ToString(), DBHelper.conn);
                if (user == null)
                {
                    MessageBox.Show("用户不存在", "青鸟温馨提示", MessageBoxButtons.OK);
                    txtUsername.Select();
                    txtUsername.Focus();
                    return;
                }
                else
                {
                    orders = Order.GetOrdersByUID(user.Uid, DBHelper.conn);
                    userInfo = UserInfo.GetUserInfoByID(user.Uid, DBHelper.conn);
                    userGroupInfo = UserGroupInfo.GetUserGroupInfoByID(user.UserGroupID, DBHelper.conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBHelper.conn.Close();
            }

            ShowUserInfo();
            ShowOrders();

            //dgvOrders.DataSource = orders;
            //SetReadOnly();

        }
        private void ShowUserInfo()
        {
            if (userInfo != null)
            {
                txtName.Text = userInfo.Name;
                txtEmail.Text = userInfo.Email;
                txtPhone.Text = userInfo.Phone;
                txtAddress.Text = userInfo.Address;
                txtRegDate.Text = userInfo.RegTime.ToString();

                numAge.Value = userInfo.Age ?? 0;

                if (userInfo.Gender != GenderType.未指定)
                {
                    if (userInfo.Gender == GenderType.男)
                    {
                        rdoBoy.Checked = true;
                    }
                    else
                    {
                        rdoGirl.Checked = true;
                    }
                }
            }
            else
            {
                txtName.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtAddress.Clear();
                txtRegDate.Clear();

                numAge.Value = 0;

                rdoBoy.Checked = false;
                rdoGirl.Checked = false;
            }
        }

        private void SetReadOnly()
        {
            foreach (Control item in this.groupUserInfo.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).ReadOnly = chkIsReadOnly.Checked;
                }
                else if (item is NumericUpDown)
                {
                    ((NumericUpDown)item).ReadOnly = chkIsReadOnly.Checked;
                }
                else if (item is RadioButton)
                {
                    ((RadioButton)item).Enabled = !chkIsReadOnly.Checked;
                }
            }

            txtRegDate.ReadOnly = true;
            btnSave.Enabled = !chkIsReadOnly.Checked;
        }
        private List<Book> books = new List<Book>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtBookID.Text = txtBookID.Text.Trim();
            if (books.Count + orders.Count >= userGroupInfo.MaxOrders)
            {
                MessageBox.Show("不能再借了","青鸟温馨提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                return;
            }
            Book book = null;
            try
            {
                DBHelper.conn.Open();
                book = Book.GetBookByID(Convert.ToInt64(txtBookID.Text), DBHelper.conn);
                if (book != null)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("select * from bookview where 书本编号=" + book.BookID, DBHelper.conn))
                    {
                        da.Fill(ds, "books");
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

            if (book != null)
            {
                books.Add(book);
            }
            else
            {
                MessageBox.Show("书籍不存在", "青鸟温馨提示", MessageBoxButtons.OK);
            }
        }
        DataSet ds = new DataSet();

        private void frmRent_Load(object sender, EventArgs e)
        {
            SetReadOnly();
            ds.Tables.Add(new DataTable("books"));
            dgvBooks.DataSource = ds.Tables["books"];
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper.conn.Open();
                foreach (Book b in books)
                {
                    Order o = new Order(user.Uid, b.BookID);
                    int result = ((IDBOperate)o).Insert(DBHelper.conn);
                    if (result > 0)
                    {
                        orders.Add(o);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("书本：{0}借出失败", b.BookID));
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

            books.Clear();
            ShowOrders();
        }
        private void ShowOrders()
        {
            if (user != null)
            {
                if (ds.Tables["orders"] != null)
                {
                    ds.Tables["orders"].Clear();
                }
                using (SqlDataAdapter da = new SqlDataAdapter("select * from orderview where 用户ID=" + user.Uid, DBHelper.conn))
                {
                    da.Fill(ds, "orders");
                    dgvOrders.DataSource = ds.Tables["orders"];
                    dgvOrders.Columns["用户ID"].Visible = false;
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (userInfo == null)
            {
                MessageBox.Show("没有用户信息，现在新建用户信息");
                userInfo = new UserInfo(user.Uid, null, null, GenderType.未指定, null, null, null);
            }
            foreach (Control item in this.groupUserInfo.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.Text = txt.Text.Trim();
                }
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("必须输入姓名", "青鸟温馨提示", MessageBoxButtons.OK);
                return;
            }


            int result = 0;
            try
            {
                userInfo.Name = txtName.Text;
                userInfo.Age = (int)numAge.Value;
                userInfo.Gender = rdoBoy.Checked | rdoGirl.Checked ? (rdoBoy.Checked ? GenderType.男 : GenderType.女) : GenderType.未指定;
                userInfo.Phone = string.IsNullOrEmpty(txtPhone.Text) ? null : txtPhone.Text;
                userInfo.Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text;

                DBHelper.conn.Open();
                try
                {
                    result = ((IDBOperate)userInfo).Insert(DBHelper.conn);
                }
                catch
                {
                    result = ((IDBOperate)userInfo).Update(DBHelper.conn);
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
                ShowUserInfo();
                chkIsReadOnly.Checked = true;
            }
            else
            {
                MessageBox.Show("保存失败", "青鸟温馨提示", MessageBoxButtons.OK);
            }
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmRent_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.frt = null;
        }

       
    }
}
