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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter da = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select * from Name");
            try
            {
                da = new SqlDataAdapter(sql, DBHelper.conn);
                da.Fill(ds, "Book");
                dataGridView1.DataSource = ds.Tables["Book"];
                DataView dv = new DataView();
                dv.RowFilter = "stu like '%{0}%'";
                dataGridView1.DataSource = dv;
                ds.Tables["Stu"].Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         
        }
    }
}
