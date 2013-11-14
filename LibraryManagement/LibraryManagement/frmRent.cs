using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace LibraryManagement
{
    public partial class FrmRent : Form
    {
        public FrmRent()
        {
            InitializeComponent();
        }
        User user;
        private List<Record> records;
        UserGroupInfo userGroupInfo;

        private void btnOK_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtUsername.Text.Trim();
            user = null;
            userGroupInfo = null;
            records = new List<Record>();
            chkIsReadOnly.Checked = true;

            try
            {
                IEnumerator<User> ie = DBHelper.Entities.Users.Where(f => f.UserName.Equals(txtUsername.Text, StringComparison.CurrentCultureIgnoreCase)).GetEnumerator();
                if (ie.MoveNext())
                {
                    user = ie.Current;
                }
                if (user == null)
                {
                    MessageBox.Show("用户不存在", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtUsername.Select();
                    txtUsername.Focus();
                    return;
                }
                else
                {
                    IEnumerator<UserGroupInfo> ie2 = DBHelper.Entities.UserGroupInfoes.Where(f => f.GroupID == user.UserGroupID).GetEnumerator();
                    if (ie2.MoveNext())
                    {
                        userGroupInfo = ie2.Current;
                    }
                    IEnumerator<Record> ie3 = DBHelper.Entities.Records.Where(f => f.UserID == user.UserID).GetEnumerator();
                    while (ie3.MoveNext())
                    {
                        records.Add(ie3.Current);
                    }

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
            ShowRecords();

            //dgvOrders.DataSource = orders;
            //SetReadOnly();

        }
        private void ShowUserInfo()
        {
            if (user != null)
            {
                txtName.Text = user.Name;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                txtAddress.Text = user.Address;

                numAge.Value = user.Age ?? 0;

                if (user.Gender != null)
                {
                    if (user.Gender == "男")
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

            btnSave.Enabled = !chkIsReadOnly.Checked;
        }
        private List<Book> books = new List<Book>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBookID.Text.Trim() == "")
            {
                MessageBox.Show("没有输入书籍编号", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("请输入会员卡号", "迅邦温馨提示");
            }
            else
            {


                txtBookID.Text = txtBookID.Text.Trim();
                if (books.Count + records.Count >= userGroupInfo.Max)
                {
                    MessageBox.Show("不能再借了，用户借阅书籍数量上线（" + userGroupInfo.Max + "本）", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                Book book = null;
                try
                {
                    int bid = Convert.ToInt32(txtBookID.Text);
                    IEnumerator<Book> ie = DBHelper.Entities.Books.Where(f => f.BookID == bid).GetEnumerator();
                    if (ie.MoveNext())
                    {
                        book = ie.Current;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (book != null)
                {
                    books.Add(book);
                }
                else
                {
                    MessageBox.Show("书籍不存在", "迅邦温馨提示", MessageBoxButtons.OK);
                }
            }
        }

        private void frmRent_Load(object sender, EventArgs e)
        {
            SetReadOnly();
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("请输入会员卡号！", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (txtBookID.Text.Trim() == "")
            {
                MessageBox.Show("请选择书籍！", "迅邦温馨提示");
            }
            else if (books.Count >= userGroupInfo.Max)
            {
                MessageBox.Show("已达到最大借书量", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            else
            {


                try
                {
                    DBHelper.conn.Open();
                    foreach (Book b in books)
                    {
                        if (b.IsRent)
                        {
                            MessageBox.Show(string.Format("书本：{0}借出失败（没有库存了！/请输入此书其余库存编号借出）", b.BookInfo.Title));
                            continue;
                        }
                        Record r = new Record();
                        r.UserID = user.UserID;
                        r.BookID = b.BookID;
                        r.OutDate = DateTime.Now;

                        DBHelper.Entities.Records.Add(r);

                    }
                    DBHelper.Entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                books.Clear();
                ShowRecords();
            }
        }
        private void ShowRecords()
        {
            if (user != null)
            {
                IEnumerator<Record> ie3 = DBHelper.Entities.Records.Where(f => f.UserID == user.UserID).GetEnumerator();
                while (ie3.MoveNext())
                {
                    records.Add(ie3.Current);
                }
                dgvOrders.DataSource = records;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("必须输入姓名", "迅邦温馨提示", MessageBoxButtons.OK);
                return;
            }


            int result = 0;
            try
            {
                user.Name = txtName.Text;
                user.Age = (int)numAge.Value;
                user.Gender = rdoBoy.Checked | rdoGirl.Checked ? (rdoBoy.Checked ? "男" : "女") : null;
                user.Phone = string.IsNullOrEmpty(txtPhone.Text) ? null : txtPhone.Text;
                user.Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text;
                user.Address = txtAddress.Text;

                result = DBHelper.Entities.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (result > 0)
            {
                ShowUserInfo();
                chkIsReadOnly.Checked = true;
            }
            else
            {
                MessageBox.Show("保存失败", "迅邦温馨提示", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            books.Clear();
        }


    }
}
