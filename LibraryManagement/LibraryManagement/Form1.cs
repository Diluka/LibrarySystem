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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataView dv = null;
        SqlDataAdapter da = null;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT   dbo.Users.UID AS 用户ID, dbo.Users.Username AS 用户名, dbo.UserInfo.Name AS 姓名, dbo.BookInfo.Title AS 书籍名称,  dbo.Orders.LeaseDate AS 借出时间, dbo.Categories.Category AS 书籍类别,  dbo.Categories.MaxDay AS 租借最大天数 FROM      dbo.Orders INNER JOIN dbo.UserInfo ON dbo.Orders.UID = dbo.UserInfo.UID INNER JOIN dbo.Users ON dbo.Orders.UID = dbo.Users.UID AND dbo.UserInfo.UID = dbo.Users.UID INNER JOIN dbo.Books ON dbo.Orders.BookID = dbo.Books.BookID INNER JOIN dbo.BookInfo ON dbo.Books.InfoID = dbo.BookInfo.InfoID INNER JOIN dbo.Categories ON dbo.BookInfo.CatID = dbo.Categories.CatID GROUP BY dbo.Users.UID, dbo.Users.Username, dbo.UserInfo.Name, dbo.BookInfo.Title, dbo.Orders.LeaseDate, dbo.Categories.Category, dbo.Categories.MaxDay");
            try
            {
                da = new SqlDataAdapter(sql, DBHelper.conn);
                da.Fill(ds, "WWW");
                dv = new DataView(ds.Tables["WWW"]);
                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("书籍名称 like '%{0}%'", textBox1.Text);
        }
    }
}
