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
    public partial class FrmAddUser : Form
    {
        public FrmAddUser()
        {
            InitializeComponent();
        }

        User user;
        UserInfo userInfo;
        DataSet ds = new DataSet();


        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select UGID,GroupName From UserGroupInfo", DBHelper.conn))
                {
                    da.Fill(ds, "usergroup");
                }

                cboUserGroup.DataSource = ds.Tables["usergroup"];
                cboUserGroup.DisplayMember = "GroupName";
                cboUserGroup.ValueMember = "UGID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (this.Tag == null)
            {
                btnSave.Text = "保  存";
                this.Text = "添加用户";
                dateRegDate.Enabled = false;
            }
            else
            {
                btnSave.Text = "修  改";
                this.Text = "修改用户";
                txtUsername.Enabled = false;

                try
                {
                    long uid = Convert.ToInt64(this.Tag);

                    DBHelper.conn.Open();

                    user = User.GetUserByID(uid, DBHelper.conn);
                    userInfo = UserInfo.GetUserInfoByID(uid, DBHelper.conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.conn.Close();
                }

                ShowData();
            }
        }

        private void ShowData()
        {
            if (user != null)
            {
                txtUsername.Text = user.Username;
                cboUserGroup.SelectedValue = user.UserGroupID;
            }
            if (userInfo != null)
            {
                txtName.Text = userInfo.Name;
                txtAge.Text = userInfo.Age + "";
                switch (userInfo.Gender)
                {
                    case GenderType.未指定:
                        rdoUndefinedGender.Checked = true;
                        break;
                    case GenderType.女:
                        rdoFemale.Checked = true;
                        break;
                    case GenderType.男:
                        rdoMale.Checked = true;
                        break;
                    default:
                        break;
                }
                txtPhone.Text = userInfo.Phone;
                txtEmail.Text = userInfo.Email;
                txtAddress.Text = userInfo.Address;
                dateRegDate.Value = userInfo.RegTime;
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
                DBHelper.conn.Open();

                if (this.Tag == null)
                {
                    user = new User(txtUsername.Text, SetPassword(), (int)cboUserGroup.SelectedValue);
                    result += ((IDBOperate)user).Insert(DBHelper.conn);
                    userInfo = new UserInfo(
                        user.Uid,
                        txtName.Text,
                        txtAge.Text == "" ? null : (int?)Convert.ToInt32(txtAge.Text),
                        rdoUndefinedGender.Checked ? GenderType.未指定 : (rdoMale.Checked ? GenderType.男 : GenderType.女),
                        txtPhone.Text == "" ? null : txtPhone.Text,
                        txtEmail.Text == "" ? null : txtEmail.Text,
                        txtAddress.Text == "" ? null : txtAddress.Text
                        );
                    result += ((IDBOperate)userInfo).Insert(DBHelper.conn);
                }
                else
                {
                    user.UserGroupID = (int)cboUserGroup.SelectedValue;
                    result += ((IDBOperate)user).Update(DBHelper.conn);
                    if (txtPassword.Text != "")
                    {
                        result += user.ChangePassword(txtPassword.Text, DBHelper.conn);
                    }
                    if (userInfo == null)
                    {
                        userInfo = new UserInfo(
                            user.Uid,
                            txtName.Text,
                            txtAge.Text == "" ? null : (int?)Convert.ToInt32(txtAge.Text),
                            rdoUndefinedGender.Checked ? GenderType.未指定 : (rdoMale.Checked ? GenderType.男 : GenderType.女),
                            txtPhone.Text == "" ? null : txtPhone.Text,
                            txtEmail.Text == "" ? null : txtEmail.Text,
                            txtAddress.Text == "" ? null : txtAddress.Text
                        );
                        result += ((IDBOperate)userInfo).Insert(DBHelper.conn);
                    }
                    else
                    {
                        userInfo.Name = txtName.Text;
                        userInfo.Age = txtAge.Text == "" ? null : (int?)Convert.ToInt32(txtAge.Text);
                        userInfo.Gender = rdoUndefinedGender.Checked ? GenderType.未指定 : (rdoMale.Checked ? GenderType.男 : GenderType.女);
                        userInfo.Email = txtEmail.Text == "" ? null : txtEmail.Text;
                        userInfo.Phone = txtPhone.Text == "" ? null : txtPhone.Text;
                        userInfo.Address = txtAddress.Text == "" ? null : txtAddress.Text;
                        userInfo.RegTime = dateRegDate.Value;
                        result += ((IDBOperate)userInfo).Update(DBHelper.conn);
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
