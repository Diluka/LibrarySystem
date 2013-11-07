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
        DataView dv;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlDataAdapter da=new SqlDataAdapter ("select * from fn_exceeded()",DBHelper.conn))
                {
                    da.Fill(ds, "exceeded");
                }

                dv = new DataView(ds.Tables["exceeded"]);
                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("DATEDIFF(D,借出日期,'{0}') < 1",dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }
    }
}
