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

        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            radioButton1.Checked = true;
            dateTimePicker1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("所有信息不能为空！", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {


                string sql = string.Format("insert into UserInfo values ('{0}',{1},{2},'{3}','{4}','{5}','{6}')");
                int result = 0;
                try
                {
                    DBHelper.conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    DBHelper.conn.Close();
                }
                if (result > 0)
                {
                    MessageBox.Show("添加成功！", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("添加失败！", "青鸟温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
