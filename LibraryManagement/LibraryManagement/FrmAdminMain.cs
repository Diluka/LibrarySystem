﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            Application.Exit();
        }

        private void Adm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmAdminMain_Load(object sender, EventArgs e)
        {
            btnBookmanage.Font = new Font(FontMgr.fonts.Families[0], btnBookmanage.Font.Size);
            btnDatamanage.Font = new Font(FontMgr.fonts.Families[0], btnDatamanage.Font.Size);
            btnLeasemanage.Font = new Font(FontMgr.fonts.Families[0], btnLeasemanage.Font.Size);
            btnExit.Font = new Font(FontMgr.fonts.Families[0], btnExit.Font.Size);
        }
    }
}
