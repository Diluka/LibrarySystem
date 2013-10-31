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

        private void button2_Click(object sender, EventArgs e)
        {
            //string openAway = this.textBox1.Text.ToString().Trim();//读取文件的路径
            //string cmdText = @"restore database " + System.Configuration.ConfigurationSettings.AppSettings["dbName"] + " from disk='" + openAway + "'";
            //BakReductSql(cmdText, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string saveAway = this.textBox2.Text.ToString().Trim();
            //string cmdText = @"backup database " + System.Configuration.ConfigurationSettings.AppSettings["dbName"] + " to disk='" + saveAway + "'";
            //BakReductSql(cmdText, true);
        }
        ///// <summary>
        ///// 对数据库的备份和恢复操作，Sql语句实现
        ///// </summary>
        ///// <param name="cmdText">实现备份或恢复的Sql语句</param>
        ///// <param name="isBak">该操作是否为备份操作，是为true否，为false</param>
        //private void BakReductSql(string cmdText, bool isBak)
        //{
        //    SqlCommand cmdBakRst = new SqlCommand();
        //    SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Library;Integrated Security=True");
        //    try
        //    {
        //        conn.Open();
        //        cmdBakRst.Connection = conn;
        //        cmdBakRst.CommandType = CommandType.Text;
        //        if (!isBak)     //如果是恢复操作
        //        {
        //            string setOffline = "Alter database GroupMessage Set Offline With rollback immediate ";
        //            string setOnline = " Alter database GroupMessage Set Online With Rollback immediate";
        //            cmdBakRst.CommandText = setOffline + cmdText + setOnline;
        //        }
        //        else
        //        {
        //            cmdBakRst.CommandText = cmdText;
        //        }
        //        cmdBakRst.ExecuteNonQuery();
        //        if (!isBak)
        //        {
        //            MessageBox.Show("恭喜你，数据成功恢复为所选文档的状态！", "系统消息");
        //        }
        //        else
        //        {
        //            MessageBox.Show("恭喜，你已经成功备份当前数据！", "系统消息");
        //        }
        //    }
        //    catch (SqlException sexc)
        //    {
        //        MessageBox.Show("失败，可能是对数据库操作失败，原因：" + sexc, "数据库错误消息");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("对不起，操作失败，可能原因：" + ex, "系统消息");
        //    }
        //    finally
        //    {
        //        cmdBakRst.Dispose();
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //}
    

        //private void CopyDataBase_Load(object sender, EventArgs e)
        //{
        //    //ServiceController sc = new ServiceController("MSSQLSERVER");

        //    //if (sc.Status == ServiceControllerStatus.Stopped)
        //    //    sc.Start();
        //}

        private void FrmDataManager_Load(object sender, EventArgs e)
        {
            textBox1.Text = "D:\\Media";
            textBox2.Text = "D:\\Media";
        }
    }
}
