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

        private MemoryStream[] skins ={
                            new MemoryStream(),
                            new MemoryStream(Skin.Calmness),
                            new MemoryStream(Skin.DeepCyan),
                            new MemoryStream(Skin.DiamondBlue),
                            new MemoryStream(Skin.Eighteen),
                            new MemoryStream(Skin.Emerald),
                            new MemoryStream(Skin.GlassBrown),
                            new MemoryStream(Skin.Longhorn),
                            new MemoryStream(Skin.MacOS),
                            new MemoryStream(Skin.Midsummer),
                            new MemoryStream(Skin.MP10),
                            new MemoryStream(Skin.MSN),
                            new MemoryStream(Skin.OneBlue),
                            new MemoryStream(Skin.Page),
                            new MemoryStream(Skin.RealOne),
                            new MemoryStream(Skin.Silver),
                            new MemoryStream(Skin.SportsBlack),
                            new MemoryStream(Skin.SteelBlack),
                            new MemoryStream(Skin.Vista1),
                            new MemoryStream(Skin.Vista2),
                            new MemoryStream(Skin.Warm),
                            new MemoryStream(Skin.Wave),
                            new MemoryStream(Skin.XPSilver),
                        };

        public frmLogin()
        {
            InitializeComponent();
        }

        private User user;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
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
                    //wait.Close();
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show("登录失败！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Show();
                }

                wait.Close();

                //MessageBox.Show("登录失败！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("登录出现错误");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                skinEngine1.MenuFont = Fonts.GetFont(FontName.方正粗圆简体, 10);
                //this.Font = Fonts.GetFont(FontName.方正粗圆简体, 9);
                skinEngine1.TitleFont = new Font("幼圆", 12, FontStyle.Bold);
                //Random rand = new Random();
                cboSkins.SelectedIndex = 0;
                    //rand.Next(cboSkins.Items.Count);//不准修改这里，想换皮肤请在运行的时候双击登陆窗

                Font font = Fonts.GetFont(FontName.叶根友毛笔行书, 18);
                btnLogin.Font = font;

                //txtUsername.Text = "admin";
                //txtPassword.Text = "admin123";
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("启动出现错误");
            }
        }

        private void cboSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                skinEngine1.SkinStream = skins[cboSkins.SelectedIndex];
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("换肤失败");
            }
        }

        private void frmLogin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label1.Visible = !label1.Visible;
            cboSkins.Visible = !cboSkins.Visible;
        }
    }
}
