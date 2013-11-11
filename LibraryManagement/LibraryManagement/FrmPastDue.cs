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
            catch (Exception)
            {
                MessageBox.Show("没有超期信息！","青鸟温馨提示");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("借出日期 >= '{0}' and 借出日期 < '{1}'", dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker1.Value.AddDays(1).ToString("yyyy-MM-dd"));
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dv.RowFilter = "";
        }

        private void frmPastDue_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.fpd = null;
        }
    }
}
