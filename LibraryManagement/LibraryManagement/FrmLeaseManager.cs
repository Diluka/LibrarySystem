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
    public partial class FrmLeaseManager : Form
    {
        public FrmLeaseManager()
        {
            InitializeComponent();
        }

        private Form frmRent;
        private Form FrmRent
        {
            get
            {
                if (frmRent == null || frmRent.IsDisposed)
                {
                    frmRent = new FrmRent();
                    frmRent.MdiParent = this;
                }
                return frmRent;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmRent.Show();

        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 租借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 续期ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form f = new BookReturnForm();
            //f.ShowDialog();
        }

        
   

  
        private Form recordForm;
        private Form RecordForm
        {
            get
            {
                if (recordForm == null || recordForm.IsDisposed)
                {
                    recordForm = new RecordForm();
                    recordForm.MdiParent = this;
                }
                return recordForm;
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            RecordForm.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private Form frmGH;
        private Form FrmGH
        {
            get
            {
                if (frmGH == null || frmGH.IsDisposed)
                {
                    //frmGH = new FrmGH();
                    frmGH.MdiParent = this;
                }
                return frmGH;
            }
        }
        private void toolStripButton2_Click_2(object sender, EventArgs e)
        {
            FrmGH.Show();
        }

    }
}
