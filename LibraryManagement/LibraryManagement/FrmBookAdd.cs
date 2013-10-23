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
    public partial class FrmBookAdd : Form
    {
        public FrmBookAdd()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBookPressManager r = new FrmBookPressManager();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmCategoryManager t = new FrmCategoryManager();
            t.Show();
        }
    }
}
