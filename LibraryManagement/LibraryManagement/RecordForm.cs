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
                da.Fill(ds, "records");
                dv = new DataView(ds.Tables["records"]);
                dgvRecords.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string fliter1 = "";
        private string fliter2 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (cboType.Text == "全部")
            {
                fliter1 = "";
            }
            else
            {
                fliter1 = string.Format("{0} like '{1}%'", cboType.Text, textBox1.Text);
            }

            dv.RowFilter = fliter1;
            if (fliter1 != "")
            {
                if (fliter2 != "")
                {
                    dv.RowFilter += " AND " + fliter2;
                }
            }
            else
            {
                if (fliter2 != "")
                {
                    dv.RowFilter = fliter2;
                }
            }


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] strs = new string[e.Node.Level];
            TreeNode node = e.Node;
            while (node.Parent != null)
            {
                strs[e.Node.Level] = e.Node.Tag.ToString();
            }
            fliter2 = string.Join(" AND ", strs);

            dv.RowFilter = fliter1;
            if (fliter1 != "")
            {
                if (fliter2 != "")
                {
                    dv.RowFilter += " AND " + fliter2;
                }
            }
            else
            {
                if (fliter2 != "")
                {
                    dv.RowFilter = fliter2;
                }
            }
        }
    }
}
