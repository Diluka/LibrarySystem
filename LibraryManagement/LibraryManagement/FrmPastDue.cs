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
    public partial class frmPastDue : Form
    {
        public frmPastDue()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter da = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT   UserInfo.Name AS 用户名称, BookInfo.Title AS 图书名称, Records.LeaseDate AS 借出时间,  Records.ReturnDate AS 归还时间, Records.RecordID AS 超期信息编号 FROM  Records INNER JOIN UserInfo ON Records.UID = UserInfo.UID CROSS JOIN BookInfo");
            try
            {
                da = new SqlDataAdapter(sql, DBHelper.conn);
                da.Fill(ds, "UUU");
                dataGridView1.DataSource = ds.Tables["UUU"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
