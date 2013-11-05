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
    public partial class FrmAddUser : Form
    {
        public FrmAddUser()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (labelTextBox7.Text != labelTextBox8.Text)
            {
                MessageBox.Show("两次密码输入不同", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (labelTextBox1.Text == "" || labelTextBox2.Text == "" || labelTextBox7.Text == "" || labelTextBox8.Text == "" ||labelTextBox3.Text == "" || labelTextBox4.Text == ""|| labelTextBox5.Text == "" || labelTextBox6.Text == "")
            {
                MessageBox.Show("请完善必填信息！", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int result = 0;
                int result2 = 0;
                try
                {
                    DBHelper.conn.Open();
                    result = AddU();
                    result2 = AddUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.conn.Close();     
                }
                if (result > 0 && result2 > 0)
                {
                    string qq = string.Format("注册成功，你的会员号为：{0}",UID);
                    MessageBox.Show(qq,"青鸟温馨提示");
                }
                else
                {
                    MessageBox.Show("注册失败","青鸟温馨提示");
                }
            }
        }

        private int AddU()
        {
            int result = 0;
            try
            {
                string sql = string.Format("insert into users values('{0}','{1}',2)", labelTextBox1.Text, labelTextBox8.Text);
                SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
                result = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());    
            }
            return result;
        }

        private int AddUI()
        {
            int result = 0;
            string Gender = "女";
            try
            {
                if (radioButton1.Checked == true)
	            {
		             Gender = "男";
	            }
                string sql = string.Format("insert into userinfo values({0},'{1}',{2},'{3}','{4}','{5}','{6}','{7}')", ID(), labelTextBox2.Text, labelTextBox3.Text,Gender , labelTextBox4.Text, labelTextBox5.Text, labelTextBox6.Text, Convert.ToDateTime(dateTimePicker1.Text));
                SqlCommand comm = new SqlCommand(sql, DBHelper.conn);
                result = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            return result;
        }

        int UID = 0;

        private int ID() 
        {
            
            try
            {
                string sql = string.Format("select UID from Users where Username = '{0}'", labelTextBox1.Text);
                SqlCommand comm = new SqlCommand(sql, DBHelper.conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    UID = Convert.ToInt32(dr["UID"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return UID;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void FrmAddUser_Load(object sender, EventArgs e)
        {

        }
    }
}
