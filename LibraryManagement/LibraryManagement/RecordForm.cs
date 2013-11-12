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
    public partial class RecordForm : Form
    {
        public RecordForm()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataView dv = null;
        SqlDataAdapter da = null;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select * from RecordView");
            try
            {
                da = new SqlDataAdapter(sql, DBHelper.conn);
                da.Fill(ds, "WWW");
                dv = new DataView(ds.Tables["WWW"]);
                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("书籍标题 like '%{0}%'", textBox1.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.f1 = null;
        }
    }
}
