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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form f = new BookInfoForm();
            f.ShowDialog();
        }

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("select * from BookInfoListView", DBHelper.conn);
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
            DBHelper.MakeCategoryTree(treeCategories);
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
                    form.ShowDialog();
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
                    form.ShowDialog();

                    forms.Add(form);
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的项！", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    form.ShowDialog();
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
                    form.ShowDialog();

                    forms.Add(form);
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的项！", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvBookInfo.SelectedRows.Count > 0)
            {
                string title = dgvBookInfo.SelectedRows[0].Cells["书籍标题"].Value.ToString();
                int iid = Convert.ToInt32(dgvBookInfo.SelectedRows[0].Cells["书籍编号"].Value);
                DialogResult result = MessageBox.Show(string.Format("确认删除《{0}》？", title), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {

                        BookInfo bookInfo = DBHelper.Entities.BookInfoes.Find(iid);
                        DBHelper.Entities.BookInfoes.Remove(bookInfo);
                        if (DBHelper.Entities.SaveChanges() > 0)
                        {
                            if (ds.Tables["books"] != null)
                            {
                                ds.Tables["books"].Clear();
                            }
                            da.Fill(ds, "books");
                        }
                        else
                        {
                            MessageBox.Show("删除失败", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            //else if (dgvBookInfo.SelectedRows.Count > 0)
            //{
            //    MessageBox.Show("书籍已借出，不能删除！", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //}
            else
            {
                MessageBox.Show("请选择要删除的项", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookInfo.SelectedRows.Count > 0)
            {
                string title = dgvBookInfo.SelectedRows[0].Cells["书籍标题"].Value.ToString();
                int iid = Convert.ToInt32(dgvBookInfo.SelectedRows[0].Cells["书籍编号"].Value);
                DialogResult result = MessageBox.Show(string.Format("确认删除《{0}》？", title), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {

                        BookInfo bookInfo = DBHelper.Entities.BookInfoes.Find(iid);
                        DBHelper.Entities.BookInfoes.Remove(bookInfo);
                        if (DBHelper.Entities.SaveChanges() > 0)
                        {
                            if (ds.Tables["books"] != null)
                            {
                                ds.Tables["books"].Clear();
                            }
                            da.Fill(ds, "books");
                        }
                        else
                        {
                            MessageBox.Show("删除失败", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            //else if (dgvBookInfo.SelectedRows.Count > 0 && a() > b())
            //{
            //    MessageBox.Show("书籍已借出，不能删除！","迅邦温馨提示",MessageBoxButtons.OK,MessageBoxIcon.Question);
            //}
            else
            {
                MessageBox.Show("请选择要删除的项", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dv.RowFilter = "类别 like '" + string.Join("/", flite) + "%'";
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
                searchField = "标题";
            }
            else
            {
                searchField = "作者";
            }
            string ch = chkBlur.Checked ? "%" : "";
            string fliter = string.Format("{0} like '{2}{1}{2}'", searchField, txtSearchString.Text, ch);
            dv.RowFilter = fliter;


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

                        foreach (DataGridViewRow row in dgvBookInfo.SelectedRows)
                        {
                            int iid = Convert.ToInt32(row.Cells["书籍编号"].Value);
                            BookInfo bookInfo = DBHelper.Entities.BookInfoes.Find(iid);
                            DBHelper.Entities.BookInfoes.Remove(bookInfo);
                        }
                        DBHelper.Entities.SaveChanges();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (ds.Tables["books"] != null)
                    {
                        ds.Tables["books"].Clear();
                    }
                    da.Fill(ds, "books");

                }

            }
            //else if (dgvBookInfo.SelectedRows.Count > 0)
            //{
            //    MessageBox.Show("有书籍书籍已借出，不能删除！","迅邦温馨提示",MessageBoxButtons.OK,MessageBoxIcon.Question);
            //}

            else
            {
                MessageBox.Show("请选择要删除的项", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        List<Form> bookForms = new List<Form>();
        private void 查看库存书本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookInfo.SelectedRows.Count != 0)
            {
                Form f = null;
                BookInfo bi = null; ;
                try
                {
                    using (LibraryEntities le = new LibraryEntities())
                    {
                        bi = le.BookInfoes.Find(dgvBookInfo.SelectedRows[0].Cells["书籍编号"].Value);
                    }

                    if (bi == null)
                    {
                        MessageBox.Show("请选择", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                    foreach (Form form in bookForms)
                    {
                        if (((BookInfo)form.Tag).BookInfoID == bi.BookInfoID)
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
                    f.ShowDialog();
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
                    f.ShowDialog();
                    bookForms.Add(f);
                }

            }
        }

        private void btnReflash_Click(object sender, EventArgs e)
        {
            Reflash();
        }

        private void Reflash()
        {
            ds.Tables["books"].Clear();
            try
            {
                da.Fill(ds, "books");
                DBHelper.MakeCategoryTree(treeCategories);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dv = new DataView(ds.Tables["books"]);
            dgvBookInfo.DataSource = dv;

            treeCategories.Nodes[0].Expand();
        }

        private void FrmBookManager_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


    }
}
