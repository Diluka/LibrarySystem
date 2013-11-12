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
using System.IO;

namespace LibraryManagement
{
    public partial class frmLogin : Form
    {

//        byte[][] skins ={new byte[0],
//            Skin.Calmness,
//Skin.DeepCyan,
//Skin.DiamondBlue,
//Skin.Eighteen,
//Skin.Emerald,
//Skin.GlassBrown,
//Skin.Longhorn,
//Skin.MacOS,
//Skin.Midsummer,
//Skin.MP10,
//Skin.MSN,
//Skin.OneBlue,
//Skin.Page,
//Skin.RealOne,
//Skin.Silver,
//Skin.SportsBlack,
//Skin.SteelBlack,
//Skin.Vista1,
//Skin.Vista2,
//Skin.Warm,
//Skin.Wave,
//            Skin.XPSilver, };
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
            cboSkins.SelectedIndex = 0;

            Font font = Fonts.GetFont(FontName.叶根友毛笔行书, 18);
            btnLogin.Font = font;

            txtUsername.Text = "admin";
            txtPassword.Text = "admin123";
        }

        private void cboSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            //skinEngine1.SkinStream = new MemoryStream(skins[cboSkins.SelectedIndex]);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
