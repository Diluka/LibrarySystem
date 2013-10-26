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
    public partial class FrmLeaseManager : Form
    {
        public FrmLeaseManager()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmBookLease p = new FrmBookLease();
            p.ShowDialog();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmBookDefer m = new FrmBookDefer();
            m.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form9 a = new Form9();
            a.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 租借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookLease p = new FrmBookLease();
            p.ShowDialog();
        }

        private void 续期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookDefer m = new FrmBookDefer();
            m.ShowDialog();
        }

        private void 归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 a = new Form9();
            a.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PastDueForm pf = new PastDueForm();
            pf.ShowDialog();
        }
    }
}
