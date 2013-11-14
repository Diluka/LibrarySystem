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
            cboType.SelectedIndex = 0;

            string sql = string.Format("select * from RecordView");
            try
            {
                da = new SqlDataAdapter(sql, DBHelper.conn);
                da.Fill(ds, "records");
                dv = new DataView(ds.Tables["records"]);
                dgvRecords.DataSource = dv;
                //dgvRecords.Columns["归还日期"].DefaultCellStyle = new DataGridViewCellStyle();
                dgvRecords.Columns["归还日期"].DefaultCellStyle.NullValue = "[未归还]";
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
            else if (cboType.Text == "藏书号")
            {
                fliter1 = string.Format("藏书号 = {0}", textBox1.Text);
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
                strs[node.Level - 1] = node.Tag.ToString();
                node = node.Parent;
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

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            txtBookID.Text = txtBookID.Text.Trim();

            if (txtBookID.Text == "")
            {
                MessageBox.Show("请输入藏书号");
                txtBookID.Focus();
                return;
            }

            try
            {
                ReturnBook(Convert.ToInt32(txtBookID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReturnBook(int bookID)
        {
            int result = 0;
            Record record = null;

            try
            {
                Book book = DBHelper.Entities.Books.Find(bookID);
                if (book == null)
                {
                    MessageBox.Show("没有此书！");
                    txtBookID.Focus();
                    return;
                }
                else if (book.IsRent)
                {
                    record = book.Records.Where(f => f.ReturnDate == null).ToArray()[0];
                    record.ReturnDate = DateTime.Now;
                    book.IsRent = false;
                    result = DBHelper.Entities.SaveChanges();
                }
                else
                {
                    MessageBox.Show("此书没有借出！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (result > 0)
            {
                Form form = new GHTC();
                form.Tag = record;
                form.ShowDialog();

                if (ds.Tables["records"] != null)
                {
                    ds.Tables["records"].Clear();
                }
                da.Fill(ds, "records");
            }
            else
            {
                MessageBox.Show("归还失败");
            }
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReturnBook(Convert.ToInt32(dgvRecords.CurrentRow.Cells["藏书号"].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvRecords.CurrentRow != null)
            {
                if (dgvRecords.CurrentRow.Cells["归还日期"].Value.ToString() == "")
                {
                    return;
                }
            }

            e.Cancel = true;
        }
    }
}
