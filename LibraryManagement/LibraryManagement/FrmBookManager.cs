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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form f = new BookInfoForm();
            f.Show();
        }

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("select * from bookmgrview", DBHelper.conn);
        DataView dv;

        private void Form2_Load(object sender, EventArgs e)
        {
            FillTree();

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

        private void FillTree()
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
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new BookInfoForm();
            f.Show();
        }

        private List<Form> forms = new List<Form>();

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (dgvBookInfo.SelectedRows.Count > 0)
            {
                Form form = null;
                string iid = dgvBookInfo.SelectedRows[0].Cells["书籍编号"].Value.ToString();

                foreach (Form f in forms)
                {
                    if (f.Tag.Equals(iid))
                    {
                        form = f;
                        break;
                    }
                }

                if (form != null && !form.IsDisposed)
                {
                    form.Show();
                    form.Activate();
                }
                else
                {
                    if (form != null)
                    {
                        forms.Remove(form);
                    }

                    form = new BookInfoForm();
                    form.Tag = iid;
                    form.Show();

                    forms.Add(form);
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的项！","青鸟温馨提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvBookInfo.SelectedRows.Count > 0)
            {
                Form form = null;
                string iid = dgvBookInfo.SelectedRows[0].Cells["书籍编号"].Value.ToString();

                foreach (Form f in forms)
                {
                    if (f.Tag.Equals(iid))
                    {
                        form = f;
                        break;
                    }
                }

                if (form != null && !form.IsDisposed)
                {
                    form.Show();
                    form.Activate();
                }
                else
                {
                    if (form != null)
                    {
                        forms.Remove(form);
                    }

                    form = new BookInfoForm();
                    form.Tag = iid;
                    form.Show();

                    forms.Add(form);
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的项！", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvBookInfo.SelectedRows.Count > 0)
            {
                string title = dgvBookInfo.SelectedRows[0].Cells["书籍标题"].Value.ToString();
                long iid = Convert.ToInt64(dgvBookInfo.SelectedRows[0].Cells["书籍编号"].Value);
                DialogResult result = MessageBox.Show(string.Format("确认删除《{0}》？", title), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DBHelper.conn.Open();
                        if (BookInfo.DelBookInfoByID(iid, DBHelper.conn) > 0)
                        {
                            if (ds.Tables["books"] != null)
                            {
                                ds.Tables["books"].Clear();
                            }
                            da.Fill(ds, "books");
                        }
                        else
                        {
                            MessageBox.Show("删除失败");
                        }
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

            }
            else
            {
                MessageBox.Show("请选择要删除的项", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookInfo.SelectedRows.Count > 0)
            {
                string title = dgvBookInfo.SelectedRows[0].Cells["书籍标题"].Value.ToString();
                long iid = Convert.ToInt64(dgvBookInfo.SelectedRows[0].Cells["书籍编号"].Value);
                DialogResult result = MessageBox.Show(string.Format("确认删除《{0}》？", title), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DBHelper.conn.Open();
                        if (BookInfo.DelBookInfoByID(iid, DBHelper.conn) > 0)
                        {
                            if (ds.Tables["books"] != null)
                            {
                                ds.Tables["books"].Clear();
                            }
                            da.Fill(ds, "books");
                        }
                        else
                        {
                            MessageBox.Show("删除失败", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

            }
            else
            {
                MessageBox.Show("请选择要删除的项", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            string sql = string.Format("select * from bookmgrview where {0} like '{1}'", searchField, chkBlur.Checked ? "%" + txtSearchString.Text + "%" : txtSearchString.Text);
            if (!chkBlur.Checked && txtSearchString.Text.Equals("null", StringComparison.CurrentCultureIgnoreCase))
            {
                sql = "select * from bookmgrview where " + searchField + " is null";
            }

            MessageBox.Show(sql);
            da.SelectCommand.CommandText = sql;
            ds.Tables["books"].Clear();
            da.Fill(ds, "books");
            //dv = new DataView(ds.Tables["books"]);
            //dgvBookInfo.DataSource = dv;

            //FillTree();
            //treeCategories.Nodes[0].Expand();

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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (dgvBookInfo.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(string.Format("确认删除已选项？"), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DBHelper.conn.Open();
                        foreach (DataGridViewRow row in dgvBookInfo.SelectedRows)
                        {
                            long iid = Convert.ToInt64(row.Cells["书籍编号"].Value);
                            BookInfo.DelBookInfoByID(iid, DBHelper.conn);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DBHelper.conn.Close();
                    }

                    if (ds.Tables["books"] != null)
                    {
                        ds.Tables["books"].Clear();
                    }
                    da.Fill(ds, "books");

                }

            }
            else
            {
                MessageBox.Show("请选择要删除的项", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        List<Form> bookForms = new List<Form>();
        private void 查看库存书本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookInfo.SelectedRows.Count != 0)
            {
                Form f=null;
                BookInfo bi = null; ;
                try
                {
                    DBHelper.conn.Open();
                    bi = BookInfo.GetBookInfoByID((long)dgvBookInfo.SelectedRows[0].Cells["书籍编号"].Value, DBHelper.conn);
                    if (bi == null)
                    {
                        MessageBox.Show("请选择");
                        return;
                    }
                    foreach (Form form in bookForms)
                    {
                        if (((BookInfo)form.Tag).InfoID == bi.InfoID)
                        {
                            f = form;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.conn.Close();
                }

                if (f != null && !f.IsDisposed)
                {
                    f.Show();
                    f.Activate();
                }
                else
                {
                    if (f != null)
                    {
                        bookForms.Remove(f);
                    }
                    f = new BookForm();
                    f.Tag = bi;
                    f.Show();
                    bookForms.Add(f);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BBBB();
        }

        private void BBBB()
        {
            ds.Tables["books"].Clear();
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


    }
}
