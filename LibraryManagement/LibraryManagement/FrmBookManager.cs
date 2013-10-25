using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryDB;

namespace LibraryManagement
{
    public partial class FrmBookManager : Form
    {
        public FrmBookManager()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmBookAdd t = new FrmBookAdd();
            t.Show();
        }

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("select * from bookmgrview", DBHelper.conn);
        DataView dv;

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                DBHelper.conn.Open();
                LibraryHelper.MakeCategoryTree(treeCategories, DBHelper.conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }


            try
            {
                da.Fill(ds, "books");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dv = new DataView(ds.Tables["books"]);
            dgvBookInfo.DataSource = dv;

            treeCategories.Nodes[0].Expand();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookAdd t = new FrmBookAdd();
            t.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmBookModify i = new FrmBookModify();
            i.Show();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookModify i = new FrmBookModify();
            i.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认删除“西游记”?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("删除成功！");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认删除“西游记”?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("删除成功！");
            }
        }

        private void treeCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            string[] flite = new string[node.Level];
            while (node.Parent != null)
            {
                flite[node.Level - 1] = node.Name;
                node = node.Parent;
            }
            dv.RowFilter = "分类 like '" + string.Join("/", flite) + "%'";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearchString.Text = txtSearchString.Text.Trim();
            string searchField;
            if (rdoISBN.Checked)
            {
                searchField = "ISBN";
            }
            else if (rdoTitle.Checked)
            {
                searchField = "书籍标题";
            }
            else
            {
                searchField = "作者";
            }

            string sql = string.Format("select * from bookmgrview where {0} like '{1}'", searchField, chkBlur.Checked ? "%" + txtSearchString.Text + "% or " + searchField + " is null" : txtSearchString.Text);
            if (!chkBlur.Checked && txtSearchString.Text.Equals("null", StringComparison.CurrentCultureIgnoreCase))
            {
                sql = "select * from bookmgrview where " + searchField + " is null";
            }

            da.SelectCommand.CommandText = sql;
            ds.Tables["books"].Clear();
            da.Fill(ds, "books");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dgvBookInfo.SelectAll();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvBookInfo.Rows)
            {
                item.Selected = false;
            }
        }


    }
}
