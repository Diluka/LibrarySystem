using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagement
{
    public partial class FrmAddUser : Form
    {
        public FrmAddUser()
        {
            InitializeComponent();
        }

        User user;

        //DataSet ds = new DataSet();


        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            try
            {
                //using (SqlDataAdapter da = new SqlDataAdapter("select GroupID,GroupName From UserGroupInfo", DBHelper.conn))
                //{
                //    da.Fill(ds, "usergroup");
                //}

                //cboUserGroup.DataSource = ds.Tables["usergroup"];
                cboUserGroup.DataSource = DBHelper.Entities.UserGroupInfoes.ToArray<UserGroupInfo>();
                cboUserGroup.DisplayMember = "GroupName";
                cboUserGroup.ValueMember = "GroupID";
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("用户组信息加载失败");
            }


            if (this.Tag == null)
            {
                btnSave.Text = "保  存";
                this.Text = "添加用户";
            }
            else
            {
                btnSave.Text = "修  改";
                this.Text = "修改用户";
                txtUsername.Enabled = false;

                try
                {
                    int uid = Convert.ToInt32(this.Tag);

                    IEnumerator<User> ie = DBHelper.Entities.Users.Where(f => f.UserID == uid).GetEnumerator();
                    if (ie.MoveNext())
                    {
                        user = ie.Current;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(ex);
                    MessageBox.Show("用户信息读取失败");
                }


                ShowData();
            }
        }

        private void ShowData()
        {
            if (user != null)
            {
                txtUsername.Text = user.UserName;
                cboUserGroup.SelectedValue = user.UserGroupID;

                txtName.Text = user.Name;
                txtAge.Text = user.Age + "";
                switch (user.Gender)
                {
                    case null:
                        rdoUndefinedGender.Checked = true;
                        break;
                    case "女":
                        rdoFemale.Checked = true;
                        break;
                    case "男":
                        rdoMale.Checked = true;
                        break;
                    default:
                        break;
                }
                txtPhone.Text = user.Phone;
                txtEmail.Text = user.Email;
                txtAddress.Text = user.Address;

            }
        }

        private bool ValidateInput()
        {
            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control c in item.Controls)
                    {
                        if (c is TextBox)
                        {
                            TextBox txt = c as TextBox;
                            txt.Text = txt.Text.Trim();
                        }
                    }
                }
            }
            if (!CheckPassword())
            {
                MessageBox.Show("密码不一致");
                return false;
            }
            if (txtName.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("必填项未填写完整");
                return false;
            }
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control c in item.Controls)
                    {
                        if (c is TextBox)
                        {
                            TextBox txt = c as TextBox;
                            txt.Clear();
                        }
                        else if (c is ComboBox)
                        {
                            ComboBox cbo = c as ComboBox;
                            cbo.SelectedIndex = 0;
                        }
                        else if (c is DateTimePicker)
                        {
                            DateTimePicker date = c as DateTimePicker;
                            date.Value = DateTime.Now;
                        }
                    }
                }
            }
            rdoUndefinedGender.Checked = true;

            ShowData();
        }

        private bool CheckPassword()
        {
            return txtPassword.Text == txtPassword2.Text;
        }
        private string SetPassword()
        {
            return txtPassword.Text == "" ? txtUsername.Text : txtPassword.Text;
        }

        private int InsertOrUpdate()
        {
            int result = 0;
            try
            {
                if (this.Tag == null)
                {
                    if (DBHelper.Entities.Users.Count(f => f.UserName == txtUsername.Text) != 0)
                    {
                        MessageBox.Show("该用户名已被使用");
                        return 0;
                    }

                    user = new User();
                    user.UserName = txtUsername.Text;
                    user.UserPWD = Tools.ToSHA1(SetPassword());
                    user.UserGroupID = ((UserGroupInfo)cboUserGroup.SelectedItem).GroupID;
                    user.Name = txtName.Text;
                    user.Age = txtAge.Text == "" ? null : (int?)Convert.ToInt32(txtAge.Text);
                    user.Gender = rdoUndefinedGender.Checked ? null : (rdoMale.Checked ? "男" : "女");
                    user.Phone = txtPhone.Text == "" ? null : txtPhone.Text;
                    user.Email = txtEmail.Text == "" ? null : txtEmail.Text;
                    user.Address = txtAddress.Text == "" ? null : txtAddress.Text;

                    DBHelper.Entities.Users.Add(user);
                    result = DBHelper.Entities.SaveChanges();
                }
                else
                {
                    user.UserName = txtUsername.Text;
                    if (txtPassword.Text != "")
                    {
                        user.UserPWD = Tools.ToSHA1(txtPassword.Text);
                    }
                    user.UserGroupID = ((UserGroupInfo)cboUserGroup.SelectedItem).GroupID;
                    user.Name = txtName.Text;
                    user.Age = txtAge.Text == "" ? null : (int?)Convert.ToInt32(txtAge.Text);
                    user.Gender = rdoUndefinedGender.Checked ? null : (rdoMale.Checked ? "男" : "女");
                    user.Phone = txtPhone.Text == "" ? null : txtPhone.Text;
                    user.Email = txtEmail.Text == "" ? null : txtEmail.Text;
                    user.Address = txtAddress.Text == "" ? null : txtAddress.Text;

                    result = DBHelper.Entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("添加用户出现错误");
            }

            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (InsertOrUpdate() > 0)
            {
                MessageBox.Show(this.Text + "成功");
            }
            else
            {
                MessageBox.Show(this.Text + "失败");
            }
        }
    }
}
