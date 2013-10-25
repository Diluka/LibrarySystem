using LibraryDB;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBHelper.con.Open();
            UserGroupInfo info = null;
            try
            {
                info = LibraryHelper.ValidateLogin2(txtUser.Text, txtPwd.Text, DBHelper.con);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                DBHelper.con.Close();
            }
            if (info != null && info.IsAdmin)
            {
                FrmAdm fa = new FrmAdm();
                fa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
