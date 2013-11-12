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
    public partial class GHTC : Form
    {
        public GHTC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GHTC_Load(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT   dbo.Records.RecordID AS 记录编号, dbo.Books.BookID AS 书本编号, dbo.BookInfo.Title AS 书籍标题, dbo.Records.LeaseDate AS 借出时间, dbo.Records.ReturnDate AS 归还时间, dbo.Users.Username AS 用户帐号, dbo.UserInfo.Name AS 用户姓名 FROM      dbo.Records INNER JOIN dbo.Users ON dbo.Records.UID = dbo.Users.UID INNER JOIN dbo.UserInfo ON dbo.Users.UID = dbo.UserInfo.UID INNER JOIN dbo.Books ON dbo.Records.BookID = dbo.Books.BookID INNER JOIN dbo.BookInfo ON dbo.Books.InfoID = dbo.BookInfo.InfoID where  RecordID = (select Top 1 RecordID  from Records  order by RecordID desc) ");
            try
            {
                DBHelper.conn.Open();
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lblID.Text = dr["书本编号"].ToString();
                    lbeName.Text = dr["书籍标题"].ToString();
                    lblJTime.Text = dr["借出时间"].ToString();
                    lblHTime.Text = dr["归还时间"].ToString();
                    lblUserID.Text = dr["用户帐号"].ToString();
                    lblUserName.Text = dr["用户姓名"].ToString();

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
