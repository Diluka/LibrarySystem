using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        DataView dv;

        private void Form2_Load(object sender, EventArgs e)
        {
            treeCategories.Nodes.Clear();
            treeCategories.Nodes.Add(new TreeNode("全部"));

            string sql = "select * from categories";

            try
            {
                DBHelper.conn.Open();
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string[] cats = dr["Category"].ToString().Split('/');
                    TreeNode root = treeCategories.Nodes[0];
                    for (int i = 0; i < cats.Length; i++)
                    {
                        if (!root.Nodes.ContainsKey(cats[i]))
                        {
                            TreeNode node = new TreeNode(cats[i]);
                            node.Name = cats[i];
                            node.Tag = cats[i];
                            root.Nodes.Add(node);
                            root = node;
                        }
                        else
                        {
                            root = root.Nodes.Find(cats[i], false)[0];
                        }
                    }
                }

                dr.Close();
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
                using (SqlDataAdapter da = new SqlDataAdapter("select * from bookmgrview", DBHelper.conn))
                {
                    da.Fill(ds, "books");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dv = new DataView(ds.Tables["books"]);
            dgvBookInfo.DataSource = dv;

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


    }
}
