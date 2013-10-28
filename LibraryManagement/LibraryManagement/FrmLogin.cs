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
using FontsPack;
using System.Runtime.InteropServices;

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
                Form form = new FrmAdminMain();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Font font = Fonts.GetFont(FontName.叶根友毛笔行书, 18);
            btnLogin.Font = font;

            txtUsername.Text = "admin";
            txtPassword.Text = "admin123";
        }
    }
}
