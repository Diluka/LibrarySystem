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
    public partial class FormUpd : Form
    {
        public FormUpd()
        {
            InitializeComponent();
        }

        private void FormUpd_Load(object sender, EventArgs e)
        {
            AAA();
        }

        private void AAA()
        {
            labelTextBox13.Text = DBHelper.Name;
            labelTextBox4.Text = DBHelper.BH;
            labelTextBox5.Text = DBHelper.Gender;
            labelTextBox6.Text = DBHelper.Age;
            labelTextBox7.Text = DBHelper.Phone;
            labelTextBox8.Text = DBHelper.Mail;
            labelTextBox9.Text = DBHelper.DiZhi;
            labelTextBox10.Text = DBHelper.ZCTime;
            labelTextBox1.Text = DBHelper.ZH;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AAA();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (labelTextBox2.Text == "" && labelTextBox11.Text == "" && labelTextBox12.Text == "")
            {
                bbb();
            }
            else if (labelTextBox2.Text != "" && labelTextBox11.Text != "" && labelTextBox12.Text != "")
            {
                bbb(); UpdU();
            }
            else
            {
                MessageBox.Show("如要修该密码请输入完整信息！");
            }
        }

        private void bbb()
        {
            int a = 0;
            string sql = string.Format("update UserInfo set Age = {0},Phone = {1},Email = '{2}',[Address] = '{3}' where UID = {4}", labelTextBox6.Text, labelTextBox7.Text, labelTextBox8.Text, labelTextBox9.Text, DBHelper.BH);
            try
            {
                DBHelper.conn.Open();
                SqlCommand com = new SqlCommand(sql, DBHelper.conn);
                a = com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBHelper.conn.Close();
            }
            if (a > 0 )
            {
                MessageBox.Show("修改成功", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("修改失败", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void UpdU()
        {
            try
            {
                DBHelper.conn.Open();
                string sql = string.Format("update Users set [Password] = '{0}' where UID = {1}", labelTextBox11.Text, DBHelper.BH);
                SqlCommand comm = new SqlCommand(sql, DBHelper.conn);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally 
            {
                DBHelper.conn.Close();
            }
        }

        private void labelTextBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
