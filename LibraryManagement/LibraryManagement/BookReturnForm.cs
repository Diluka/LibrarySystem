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
    public partial class BookReturnForm : Form
    {
        public BookReturnForm()
        {
            InitializeComponent();
        }

        private void BookReturnForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            txtBookID.Text = txtBookID.Text.Trim();

            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                MessageBox.Show("请输入书本编号");
                return;
            }
        }
    }
}
