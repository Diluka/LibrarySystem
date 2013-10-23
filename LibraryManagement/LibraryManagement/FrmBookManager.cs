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
            FrmBookAppend t = new FrmBookAppend();
            t.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookAppend t = new FrmBookAppend();
            t.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmAmend i = new FrmAmend();
            i.Show();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAmend i = new FrmAmend();
            i.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          DialogResult result =  MessageBox.Show("确认删除“西游记”?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
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
