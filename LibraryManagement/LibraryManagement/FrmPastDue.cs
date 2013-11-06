using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LibraryManagement
{
    public partial class frmPastDue : Form
    {
        public frmPastDue()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter da = null;
        DataView dv = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            //string sql = string.Format("select * from fn_exceeded()");
            //try
            //{
            //    da = new SqlDataAdapter(sql, DBHelper.conn);
            //    da.Fill(ds, "UUU");
            //    dataGridView1.DataSource = ds.Tables["UUU"];
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from fn_exceeded(@uid)", textBox1.Text);
            try
            {
                da = new SqlDataAdapter(sql, DBHelper.conn);
                da.Fill(ds, "UUU");
                dv = new DataView ( ds.Tables["UUU"]);
                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
