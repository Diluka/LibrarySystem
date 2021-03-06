﻿using System;
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
    public partial class FrmCategoryManager : Form
    {
        public FrmCategoryManager()
        {
            InitializeComponent();
        }

        private void FrmCategoryManager_Load(object sender, EventArgs e)
        {
            try
            {
                DBHelper.MakeCategoryTree(treeCategories);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("加载分类信息出错");
            }

            treeCategories.Nodes[0].Expand();
        }

        private void treeCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ISetCAP target = this.Owner as ISetCAP;
            Category c = e.Node.Tag as Category;

            if (target != null && c != null)
            {
                target.SetCategory(c);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtSearchString.Text = txtSearchString.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearchString.Text))
            {
                TreeNode[] result = treeCategories.Nodes.Find(txtSearchString.Text, true);
                if (result.Length > 0)
                {
                    treeCategories.CollapseAll();

                    foreach (TreeNode node in result)
                    {
                        node.Expand();
                    }

                    result[0].Checked = true;
                    treeCategories.Nodes[0].Expand();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSearchString.Text = txtSearchString.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearchString.Text))
            {
                string[] cats = txtSearchString.Text.Split('/');
                TreeNode node = treeCategories.Nodes[0];
                int result = 0;
                foreach (string s in cats)
                {
                    TreeNode[] nodes = node.Nodes.Find(s, false);
                    if (nodes.Length > 0)
                    {
                        result += nodes.Length;
                        node = nodes[0];
                    }
                    else
                    {
                        result = 0;
                        break;
                    }
                }

                if (result == 0)
                {
                    DialogResult dr = MessageBox.Show(string.Format("是否要创建新类别'{0}'？这时应该是用'/'符号表示层次关系。(默认借阅天数：30天)", txtSearchString.Text), "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Category c = new Category();
                        c.CategoryName = txtSearchString.Text;
                        c.MaxDay = 30;
                        int result2 = 0;

                        try
                        {

                            DBHelper.Entities.Categories.Add(c);
                            result2 = DBHelper.Entities.SaveChanges();


                            if (result2 > 0)
                            {
                                DBHelper.MakeCategoryTree(treeCategories);
                                treeCategories.Nodes[0].Expand();
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(ex);
                            //MessageBox.Show(ex.Message);
                        }

                        if (result2 <= 0)
                        {
                            MessageBox.Show("添加失败！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            TreeNode node = treeCategories.SelectedNode;
            if (node == null)
            {
                return;
            }

            Category c = node.Tag as Category;
            if (c == null)
            {
                return;
            }


            DialogResult dr = MessageBox.Show(string.Format("确实要删除类别'{0}'吗？", c.CategoryName), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            int result = 0;

            try
            {
                DBHelper.Entities.Categories.Remove(c);
                result = DBHelper.Entities.SaveChanges();

                if (result > 0)
                {
                    DBHelper.MakeCategoryTree(treeCategories);

                    treeCategories.Nodes[0].Expand();
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                //MessageBox.Show(ex.Message);
            }

            if (result <= 0)
            {
                MessageBox.Show("删除失败，只能删除未关联的分类", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //treeCategories.CollapseAll();
            //treeCategories.Nodes[0].Expand();

            treeCategories.SelectedNode = null;
            ISetCAP target = this.Owner as ISetCAP;
            if (target != null)
            {
                target.SetCategory(null);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //e.Cancel = treeCategories.SelectedNode == null;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDel_Click(sender, e);
        }

    }
}
