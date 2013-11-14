using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace LibraryManagement
{
    public partial class GHTC : Form
    {
        public GHTC()
        {
            InitializeComponent();
        }

        private void GHTC_Load(object sender, EventArgs e)
        {
            Record record = this.Tag as Record;
            if (record == null)
            {
                MessageBox.Show("没有书籍信息");
                this.Close();
            }
            else
            {
                txtBookID.Text = record.BookID.ToString();
                txtTitle.Text = record.Book.BookInfo.Title;
                txtOutDate.Text = record.OutDate.ToString();
                txtReturnDate.Text = record.ReturnDate.ToString();
                txtUserName.Text = record.User.UserName;
                txtName.Text = record.User.Name;
                if (record.Book.BookInfo.Cover != null)
                {
                    picCover.Image = Image.FromStream(new MemoryStream(record.Book.BookInfo.Cover));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
