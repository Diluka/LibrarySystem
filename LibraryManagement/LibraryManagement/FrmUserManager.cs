using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryDB;
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
        DataSet ds = new DataSet();
        DataView dv;
        private void FrmDataManager_Load(object sender, EventArgs e)
        {
            GetAll();

        }

        public void GetAll()
        {
            try
            {
                if (ds.Tables["users"] != null)
                {
                    ds.Tables["users"].Clear();
                }
                using (SqlDataAdapter da = new SqlDataAdapter("select * from userview", DBHelper.conn))
                {
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
                string username = dgvUsers.CurrentRow.Cells["用户名"].Value.ToString();
                DialogResult result = MessageBox.Show(string.Format("确认要删除编号为《{0}》的用户？", username), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int sqlresult = 0;
                    try
                    {
                        DBHelper.conn.Open();
                        sqlresult = User.DelUserByUsername(username, DBHelper.conn);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DBHelper.conn.Close();
                    }

                    if (sqlresult > 0)
                    {
                        MessageBox.Show("删除成功！");
                        GetAll();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }

            }
            else
            {
                MessageBox.Show("请选择要删除的项", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                form.Tag = dgvUsers.CurrentRow.Cells["用户ID"].Value;
                form.ShowDialog();
                GetAll();
            }
            else
            {
                MessageBox.Show("请选择要修改的用户", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmUserManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.fum = null;
        }


    }
}
