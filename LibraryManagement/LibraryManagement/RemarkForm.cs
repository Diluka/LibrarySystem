using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class RemarkForm : Form
    {
        public RemarkForm()
        {
            InitializeComponent();
        }
        Book book;
        private void RemarkForm_Load(object sender, EventArgs e)
        {
            try
            {
                book = (Book)this.Tag;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("藏书信息错误");
                this.Close();
            }

            try
            {
                txtRemark.Text = book.Remark;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("加载备注信息错误");
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRemark();
        }

        private void SaveRemark()
        {
            int result = 0;
            try
            {
                book.Remark = txtRemark.Text;
                result = DBHelper.Entities.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("保存备注出错");
            }

            if (result > 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private void 重新读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtRemark.Text = book.Remark;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("加载备注信息错误");
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemarkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtRemark.Text != book.Remark)
            {
                DialogResult result = MessageBox.Show("有未保存的修改，是否保存？", "退出提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        break;
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Yes:
                        SaveRemark();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
