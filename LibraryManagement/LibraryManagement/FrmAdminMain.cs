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

        private Form frmBookManager;
        private Form FrmBookManager
        {
            get
            {
                if (frmBookManager == null || frmBookManager.IsDisposed)
                {
                    frmBookManager = new FrmBookManager();
                }
                return frmBookManager;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBookManager.Show();
            FrmBookManager.Activate();
        }

        private Form frmUserManager;
        private Form FrmUserManager
        {
            get
            {
                if (frmUserManager == null || frmUserManager.IsDisposed)
                {
                    frmUserManager = new FrmUserManager();
                }
                return frmUserManager;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FrmUserManager.Show();
            FrmUserManager.Activate();
        }

        private Form frmLeaseManager;
        private Form FrmLeaseManager
        {
            get
            {
                if (frmLeaseManager == null || frmLeaseManager.IsDisposed)
                {
                    frmLeaseManager = new FrmLeaseManager();
                }
                return frmLeaseManager;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLeaseManager.Show();
            FrmLeaseManager.Activate();
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
