using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LibraryManagement
{
    public partial class FrmDataManager : Form
    {
        //TO-DO: 不兼容代码，全部重写
        public FrmDataManager()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmAddUser fau = new FrmAddUser();
            fau.ShowDialog();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter da = null;
        private void FrmDataManager_Load(object sender, EventArgs e)
        {
            Se();
            
        }

        public void Se()
        {
            string sql = string.Format("SELECT   UID AS 用户编号, Name AS 用户姓名, Age AS 用户年龄, Gender AS 用户性别, Phone AS 电话号码, Email AS 电子邮件, Address AS 通讯地址, RegTime AS 注册时间 FROM UserInfo");
            try
            {
                da = new SqlDataAdapter(sql, DBHelper.conn);
                da.Fill(ds, "UserInfo");
                dataGridView1.DataSource = ds.Tables["UserInfo"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        string title = "";
        
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                title = dataGridView1.SelectedRows[0].Cells["用户编号"].Value.ToString();
                long iid = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["用户编号"].Value);
                DialogResult result = MessageBox.Show(string.Format("确认要删除编号为《{0}》的用户？", title), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int a = 0;
                    string sql = string.Format("delete from UserInfo where UID = {0}",title);
                    try
                    {
                        DBHelper.conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                        a = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    finally 
                    {
                        DBHelper.conn.Close();
                    }
                    if (a > 0)
                    {
                        del();
                        MessageBox.Show("删除成功！");
                        ds.Tables["UserInfo"].Clear();
                        Se();
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
        private int del() 
        {
            int b = 0;
            string sql = string.Format("delete from Users where UID = {0}",title);
            try
            {
                DBHelper.conn.Open();
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                b =  cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                DBHelper.conn.Close();
            }
            return b;

        }
        private void FrmDataManager_Activated(object sender, EventArgs e)
        {
            ds.Tables["UserInfo"].Clear();
            Se();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
               
                DBHelper.BH = dataGridView1.SelectedRows[0].Cells["用户编号"].Value.ToString();
                DBHelper.Name = dataGridView1.SelectedRows[0].Cells["用户姓名"].Value.ToString();
                DBHelper.Age = dataGridView1.SelectedRows[0].Cells["用户年龄"].Value.ToString(); 
                DBHelper.Gender = dataGridView1.SelectedRows[0].Cells["用户性别"].Value.ToString(); 
                DBHelper.Phone = dataGridView1.SelectedRows[0].Cells["电话号码"].Value.ToString();
                DBHelper.Mail = dataGridView1.SelectedRows[0].Cells["电子邮件"].Value.ToString(); 
                DBHelper.DiZhi = dataGridView1.SelectedRows[0].Cells["通讯地址"].Value.ToString(); 
                DBHelper.ZCTime = dataGridView1.SelectedRows[0].Cells["注册时间"].Value.ToString();
                string sql = string.Format("select * from Users where UID = {0}",DBHelper.BH);
                try
                {
                    DBHelper.conn.Open();
                    SqlCommand cmd = new SqlCommand(sql,DBHelper.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        DBHelper.ZH = dr["Username"].ToString();
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
                long iid = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["用户编号"].Value);
                FormUpd fu = new FormUpd();
                fu.ShowDialog();
  

            }
            else
            {
                MessageBox.Show("请选择要修改的用户", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     
    }
}
