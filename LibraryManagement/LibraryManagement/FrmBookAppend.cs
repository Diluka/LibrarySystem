using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class FrmBookAppend : Form
    {
        public FrmBookAppend()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBookconcernManager r = new FrmBookconcernManager();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmSortManager t = new FrmSortManager();
            t.Show();
        }
    }
}
