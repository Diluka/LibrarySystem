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
        public FrmDataManager()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection con = new SqlConnection("server=.;pwd=123456;uid=sa;database=master");

            //    string sql = "BACKUP DATABASE " + textBox1.Text + " TO DISK = 'c:\\test\\" + textBox1.Text + ".bak' "

            //                  + " USE master GO RESTORE DATABASE " + textBox1.Text + " FROM DISK = 'c:\\test\\" + textBox1.Text + ".bak ' WITH REPLACE, " +

            //                 "MOVE '" + textBox1.Text + "' TO 'c:\\test\\" + textBox1.Text + ".mdf', " +

            //                 "MOVE '" + textBox1.Text + "_log' TO 'c:\\test\\" + textBox1.Text + "_log.ldf'";

            //    SqlCommand com = new SqlCommand(sql, con);

            //    con.Open();

            //    com.ExecuteNonQuery();

            //    MessageBox.Show("数据库备份成功！");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("数据库备份失败！");
            //}

        }

        private void CopyDataBase_Load(object sender, EventArgs e)
        {
            //ServiceController sc = new ServiceController("MSSQLSERVER");

            //if (sc.Status == ServiceControllerStatus.Stopped)
            //    sc.Start();
        }
    }
}
