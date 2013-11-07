using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FontsPack;

namespace LibraryManagement
{
    public partial class FrmAdminMain : Form
    {
        public FrmAdminMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DBHelper.fbm == null)
            {
                DBHelper.fbm = new FrmBookManager();
                
                DBHelper.fbm.Show();
            }
            else
            {
                DBHelper.fbm.Focus();
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (DBHelper.fum == null)
            {
                DBHelper.fum = new FrmUserManager();
                
                DBHelper.fum.Show();
            }
            else
            {
                DBHelper.fum.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DBHelper.flm == null)
            {
                DBHelper.flm = new FrmLeaseManager();
                
                DBHelper.flm.Show();
            }
            else
            {
                DBHelper.flm.Focus();
            }
            
            
        }

        private void Adm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmAdminMain_Load(object sender, EventArgs e)
        {
            Font font = Fonts.GetFont(FontName.叶根友毛笔行书, 24);
            btnBookmanage.Font = font;
            btnDatamanage.Font = font;
            btnLeasemanage.Font = font;
            btnExit.Font = font;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                b.BackColor = Color.LightCyan;
            }
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                b.BackColor = Color.Transparent;
            }
        }
    }
}
