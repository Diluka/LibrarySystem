using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using FontsPack;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.Common;

namespace LibraryManagement
{
    public partial class frmLogin : Form
    {

        private byte[][] skins ={
                            new byte[0],
                            Skin.Calmness,
                            Skin.DeepCyan,
                            Skin.DiamondBlue,
                            Skin.Eighteen,
                            Skin.Emerald,
                            Skin.GlassBrown,
                            Skin.Longhorn,
                            Skin.MacOS,
                            Skin.Midsummer,
                            Skin.MP10,
                            Skin.MSN,
                            Skin.OneBlue,
                            Skin.Page,
                            Skin.RealOne,
                            Skin.Silver,
                            Skin.SportsBlack,
                            Skin.SteelBlack,
                            Skin.Vista1,
                            Skin.Vista2,
                            Skin.Warm,
                            Skin.Wave,
                            Skin.XPSilver,
                        };

        public frmLogin()
        {
            InitializeComponent();
        }

        private User user;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form wait = new WaitForm();
            wait.Show();
            this.Hide();

            IEnumerator<User> ie = DBHelper.Entities.Users.Where(f => f.UserName.Equals(txtUsername.Text, StringComparison.CurrentCultureIgnoreCase)).GetEnumerator();

            if (ie.MoveNext())
            {
                user = ie.Current;
            }

            

            if (user != null && user.UserPWD.Equals(Tools.ToSHA1(txtPassword.Text)) && user.UserGroupInfo.IsAdmin)
            {
                Form form = new FrmAdminMain();
                form.Show();
                wait.Close();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败！", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Show();
            }


            //MessageBox.Show("登录失败！", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DBHelper.Entities.Database.Initialize(false);

            skinEngine1.MenuFont = Fonts.GetFont(FontName.方正粗圆简体, 10);
            //this.Font = Fonts.GetFont(FontName.方正粗圆简体, 9);
            skinEngine1.TitleFont = new Font("幼圆", 12, FontStyle.Bold);
            cboSkins.SelectedIndex = 0;//不准修改这里，想换皮肤请在运行的时候双击登陆窗

            Font font = Fonts.GetFont(FontName.叶根友毛笔行书, 18);
            btnLogin.Font = font;

            txtUsername.Text = "admin";
            txtPassword.Text = "admin123";
        }

        private void cboSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            skinEngine1.SkinStream = new MemoryStream(skins[cboSkins.SelectedIndex]);
        }

        private void frmLogin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label1.Visible = !label1.Visible;
            cboSkins.Visible = !cboSkins.Visible;
        }
    }
}
