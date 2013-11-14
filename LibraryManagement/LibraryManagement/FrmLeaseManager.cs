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

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }


}

