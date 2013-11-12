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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataView dv = null;
        SqlDataAdapter da = null;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select * from OrderView");
            try
            {
                da = new SqlDataAdapter(sql, DBHelper.conn);
                da.Fill(ds, "WWW");
                dv = new DataView(ds.Tables["WWW"]);
                dgvOrders.DataSource = dv;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("书籍名称 like '%{0}%'", txtSearch.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.f1 = null;
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
