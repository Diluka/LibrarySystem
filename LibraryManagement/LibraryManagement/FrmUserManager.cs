using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace LibraryManagement
{
    public partial class FrmUserManager : Form
    {
        public FrmUserManager()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form form = new FrmAddUser();
            form.ShowDialog();
            GetAll();
        }
        private void FrmDataManager_Load(object sender, EventArgs e)
        {
            GetAll();

        }

        private DataSet ds = new DataSet();
        private DataView dv;
        public void GetAll()
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select * from userview", DBHelper.conn))
                {
                    if (ds.Tables["users"] != null)
                    {
                        ds.Tables["users"].Clear();
                    }
                    da.Fill(ds, "users");
                    dv = new DataView(ds.Tables["users"]);
                }

                dgvUsers.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string username = dgvUsers.CurrentRow.Cells["账户"].Value.ToString();
                DialogResult result = MessageBox.Show(string.Format("确认要删除编号为《{0}》的用户？", username), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int sqlresult = 0;
                    try
                    {
                        IEnumerator<User> ie = DBHelper.Entities.Users.Where(f => f.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase)).GetEnumerator();
                        if (ie.MoveNext())
                        {
                            DBHelper.Entities.Users.Remove(ie.Current);
                            sqlresult = DBHelper.Entities.SaveChanges();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    if (sqlresult > 0)
                    {
                        MessageBox.Show("删除失败！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        GetAll();
                    }
                    else
                    {
                        MessageBox.Show("删除成功！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }

            }
            else
            {
                MessageBox.Show("请选择要删除的项", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmDataManager_Activated(object sender, EventArgs e)
        {
            GetAll();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            if (dgvUsers.SelectedRows.Count > 0)
            {
                Form form = new FrmAddUser();
                form.Tag = dgvUsers.CurrentRow.Cells["用户编号"].Value;
                form.ShowDialog();
                GetAll();
            }
            else
            {
                MessageBox.Show("请选择要修改的用户", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtUserName.Text = txtUserName.Text.Trim();
            dv.RowFilter = string.Format("账户 like '{0}%'", txtUserName.Text);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dv.RowFilter = "";
            txtUserName.Clear();
        }
    }
}
