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
    public partial class ZuoZe : Form
    {
        public ZuoZe()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void ZuoZe_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select * from Authors");
            try
            {
                DBHelper.conn.Open();
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                SqlDataAdapter da = new SqlDataAdapter();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally 
            {
                DBHelper.conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
