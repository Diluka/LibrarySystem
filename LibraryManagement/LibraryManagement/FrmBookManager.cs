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

        private void Form2_Load(object sender, EventArgs e)
        {
            string sql = "select * from categories";

            try
            {
                DBHelper.conn.Open();
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string[] cats = dr["Category"].ToString().Split('/');
                    TreeNode root = treeCategories.Nodes[cats[0]] ?? treeCategories.Nodes[0];
                    foreach (string item in cats)
                    {
                        TreeNode node = new TreeNode(item);
                        node.Tag = item;
                        root.Nodes.Add(node);
                        root = node;
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


    }
}
