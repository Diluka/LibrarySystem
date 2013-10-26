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
            //string connectionString = Properties.Settings.Default.mydbConnectionString;

            //string strSQL = @"Backup Database Library To disk=’D:\Backup\NorthwindCS_Full_20070908.bak’ ";
            //SqlCommand sqlCmd = new SqlCommand(strSQL,DBHelper.conn);
            //if (MessageBox.Show("文件将保存在C盘目录下", "提示", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        DBHelper.conn.Open();
            //        sqlCmd.ExecuteNonQuery();
            //        MessageBox.Show("备份成功!");
            //    }
            //    catch
            //    {
            //        sqlCmd.Dispose();
            //        DBHelper.conn.Close();
            //        MessageBox.Show("备份失败!");
            //    }
            //}
//            private void button1_Click(object sender, EventArgs e) 
//{ 
//try 
//{ 
//string backupFolder = System.IO.Path.Combine(Application.StartupPath, "data"); 
//if (!System.IO.Directory.Exists(backupFolder))//判断文件夹是否存在 
//{ 
////创建文件夹 
//System.IO.Directory.CreateDirectory(backupFolder); 
//} 
//string backupFileName = System.IO.Path.Combine(backupFolder, DateTime.Today.ToString("yyyyMMdd.bak")); 

//string sqltxt = string.Format("BACKUP DATABASE [] TO DISK=''", backupFileName); 
//SqlConnection conn = baseclass.DBConn.cycon(); 
//conn.Open(); 
//SqlCommand cmd = new SqlCommand(sqltxt, conn); 
//cmd.ExecuteNonQuery(); 
//conn.Close(); 
//MessageBox.Show("备份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
////this.Close(); 
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
