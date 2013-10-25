using LibraryDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

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
            DBHelper.conn.Open();
            UserGroupInfo info = null;
            try
            {
                info = LibraryHelper.ValidateLogin2(txtUsername.Text, txtPassword.Text, DBHelper.conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                DBHelper.conn.Close();
            }
            if (info != null && info.IsAdmin)
            {
                FrmAdminMain fa = new FrmAdminMain();
                fa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnLogin.Font = new Font(FontMgr.fonts.Families[0], btnLogin.Font.Size);
        }
    }
}
