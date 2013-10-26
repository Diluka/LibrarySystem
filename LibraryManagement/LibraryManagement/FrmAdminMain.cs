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
            FrmBookManager a = new FrmBookManager();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmDataManager o = new FrmDataManager();
            o.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLeaseManager m = new FrmLeaseManager();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuanYu gy = new GuanYu();
            gy.Show();
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
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }
    }
}
