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
    public partial class FrmLeaseManager : Form
    {
        public FrmLeaseManager()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (DBHelper.frt == null)
            {
                DBHelper.frt = new FrmRent();
                DBHelper.frt.MdiParent = this;
                DBHelper.frt.Show();
            }
            else
            {
                DBHelper.frt.Focus();
            }

        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmBookDefer m = new FrmBookDefer();
            m.MdiParent = this;
            m.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (DBHelper.brf == null)
            {
                DBHelper.brf = new BookReturnForm();
                DBHelper.brf.MdiParent = this;
                DBHelper.brf.Show();
            }
            else
            {
                DBHelper.brf.Focus();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 租借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookLease p = new FrmBookLease();
            p.MdiParent = this;
            p.ShowDialog();
        }

        private void 续期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FrmBookDefer();
            f.ShowDialog();
        }

        private void 归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form f = new BookReturnForm();
            //f.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (DBHelper.fpd == null)
            {
                DBHelper.fpd = new frmPastDue();
                DBHelper.fpd.MdiParent = this;
                DBHelper.fpd.Show();
            }
            else
            {
                DBHelper.fpd.Focus();
            }

        }

        private void FrmLeaseManager_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (DBHelper.f1 == null)
            {
                DBHelper.f1 = new OrderForm();
                DBHelper.f1.MdiParent = this;
                DBHelper.f1.Show();
            }
            else
            {
                DBHelper.f1.Focus();
            }
        }

        private void FrmLeaseManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.flm = null;
        }
        private Form recordForm;
        private Form RecordForm
        {
            get
            {
                if (recordForm == null || recordForm.IsDisposed)
                {
                    recordForm = new RecordForm();
                    recordForm.MdiParent = this;
                }
                return recordForm;
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            RecordForm.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //private List<Order> orders;
        //private void btnOK_Click(object sender, EventArgs e)
        //{
        //    txtUsername.Text = txtUsername.Text.Trim();
        //    user = null;
        //    userInfo = null;
        //    groupUserInfo = null;
        //    chkIsReadOnly.Checked = true;
        //    orders = null;

        //    tryC:\Users\Administrator\Source\Repos\LibrarySystem\LibraryManagement\LibraryManagement\DBHelper.cs
        //    {
        //        DBHelper.conn.Open();
        //        user = User.GetUserByName(txtUsername.Text, DBHelper.conn);
        //        if (user == null)
        //        {
        //            MessageBox.Show("用户不存在", "青鸟温馨提示", MessageBoxButtons.OK);
        //            txtUsername.Select();
        //            txtUsername.Focus();
        //            return;
        //        }
        //        else
        //        {
        //            orders = Order.GetOrdersByUID(user.Uid, DBHelper.conn);
        //            userInfo = UserInfo.GetUserInfoByID(user.Uid, DBHelper.conn);
        //            userGroupInfo = UserGroupInfo.GetUserGroupInfoByID(user.UserGroupID, DBHelper.conn);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        DBHelper.conn.Close();
        //    }

        //    ShowUserInfo();
        //    ShowOrders();

        //    //dgvOrders.DataSource = orders;
        //    //SetReadOnly();

        //}

        //private void ShowUserInfo()
        //{
        //    if (userInfo != null)
        //    {
        //        txtName.Text = userInfo.Name;
        //        txtEmail.Text = userInfo.Email;
        //        txtPhone.Text = userInfo.Phone;
        //        txtAddress.Text = userInfo.Address;
        //        txtRegDate.Text = userInfo.RegTime.ToString();

        //        numAge.Value = userInfo.Age ?? 0;

        //        if (userInfo.Gender != GenderType.未指定)
        //        {
        //            if (userInfo.Gender == GenderType.男)
        //            {
        //                rdoBoy.Checked = true;
        //            }
        //            else
        //            {
        //                rdoGirl.Checked = true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        txtName.Clear();
        //        txtEmail.Clear();
        //        txtPhone.Clear();
        //        txtAddress.Clear();
        //        txtRegDate.Clear();

        //        numAge.Value = 0;

        //        rdoBoy.Checked = false;
        //        rdoGirl.Checked = false;
        //    }
        //}

        //private void SetReadOnly()
        //{
        //    foreach (Control item in this.groupUserInfo.Controls)
        //    {
        //        if (item is TextBox)
        //        {
        //            ((TextBox)item).ReadOnly = chkIsReadOnly.Checked;
        //        }
        //        else if (item is NumericUpDown)
        //        {
        //            ((NumericUpDown)item).ReadOnly = chkIsReadOnly.Checked;
        //        }
        //        else if (item is RadioButton)
        //        {
        //            ((RadioButton)item).Enabled = !chkIsReadOnly.Checked;
        //        }
        //    }

        //    txtRegDate.ReadOnly = true;
        //    btnSave.Enabled = !chkIsReadOnly.Checked;
        //}

        //private void chkIsReadOnly_CheckedChanged(object sender, EventArgs e)
        //{
        //    SetReadOnly();
        //    if (chkIsReadOnly.Checked)
        //    {
        //        ShowUserInfo();
        //    }
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (userInfo == null)
        //    {
        //        MessageBox.Show("没有用户信息，现在新建用户信息");
        //        userInfo = new UserInfo(user.Uid, null, null, GenderType.未指定, null, null, null);
        //    }
        //    foreach (Control item in this.groupUserInfo.Controls)
        //    {
        //        if (item is TextBox)
        //        {
        //            TextBox txt = item as TextBox;
        //            txt.Text = txt.Text.Trim();
        //        }
        //    }

        //    if (txtName.Text == "")
        //    {
        //        MessageBox.Show("必须输入姓名","青鸟温馨提示",MessageBoxButtons.OK);
        //        return;
        //    }


        //    int result = 0;
        //    try
        //    {
        //        userInfo.Name = txtName.Text;
        //        userInfo.Age = (int)numAge.Value;
        //        userInfo.Gender = rdoBoy.Checked | rdoGirl.Checked ? (rdoBoy.Checked ? GenderType.男 : GenderType.女) : GenderType.未指定;
        //        userInfo.Phone = string.IsNullOrEmpty(txtPhone.Text) ? null : txtPhone.Text;
        //        userInfo.Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text;

        //        DBHelper.conn.Open();
        //        try
        //        {
        //            result = ((IDBOperate)userInfo).Insert(DBHelper.conn);
        //        }
        //        catch
        //        {
        //            result = ((IDBOperate)userInfo).Update(DBHelper.conn);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        DBHelper.conn.Close();
        //    }

        //    if (result > 0)
        //    {
        //        ShowUserInfo();
        //        chkIsReadOnly.Checked = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("保存失败", "青鸟温馨提示", MessageBoxButtons.OK);
        //    }
        //}

        //private List<Book> books = new List<Book>();

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    txtBookID.Text = txtBookID.Text.Trim();
        //    if (books.Count + orders.Count >= userGroupInfo.MaxOrders)
        //    {
        //        MessageBox.Show("不能再借了");
        //        return;
        //    }
        //    Book book = null;
        //    try
        //    {
        //        DBHelper.conn.Open();
        //        book = Book.GetBookByID(Convert.ToInt64(txtBookID.Text), DBHelper.conn);
        //        if (book != null)
        //        {
        //            using (SqlDataAdapter da = new SqlDataAdapter("select * from bookview where 书本编号=" + book.BookID, DBHelper.conn))
        //            {
        //                da.Fill(ds, "books");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        DBHelper.conn.Close();
        //    }

        //    if (book != null)
        //    {
        //        books.Add(book);
        //    }
        //    else
        //    {
        //        MessageBox.Show("书籍不存在", "青鸟温馨提示", MessageBoxButtons.OK);
        //    }

        //}

        //DataSet ds = new DataSet();
        //private void FrmLeaseManager_Load(object sender, EventArgs e)
        //{
        //    //SetReadOnly();
        //    //ds.Tables.Add(new DataTable("books"));
        //    //dgvBooks.DataSource = ds.Tables["books"];
        //}

        //private void btnOK2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DBHelper.conn.Open();
        //        foreach (Book b in books)
        //        {
        //            Order o = new Order(user.Uid, b.BookID);
        //            int result = ((IDBOperate)o).Insert(DBHelper.conn);
        //            if (result > 0)
        //            {
        //                orders.Add(o);
        //            }
        //            else
        //            {
        //                MessageBox.Show(string.Format("书本：{0}借出失败", b.BookID));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        DBHelper.conn.Close();
        //    }

        //    books.Clear();
        //    ShowOrders();
        //}

        //private void ShowOrders()
        //{
        //    if (user != null)
        //    {
        //        if (ds.Tables["orders"] != null)
        //        {
        //            ds.Tables["orders"].Clear();
        //        }
        //        using (SqlDataAdapter da = new SqlDataAdapter("select * from orderview where 用户ID=" + user.Uid, DBHelper.conn))
        //        {
        //            da.Fill(ds, "orders");
        //            dgvOrders.DataSource = ds.Tables["orders"];
        //            dgvOrders.Columns["用户ID"].Visible = false;
        //        }
        //    }

        //}

    }
}
