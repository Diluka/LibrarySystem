using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    /// <summary>
    /// 书本类
    /// </summary>
    public class Book : IDBOperate
    {
        /// <summary>
        /// 书本编号
        /// </summary>
        public long BookID { get; private set; }
        /// <summary>
        /// 书籍编号
        /// </summary>
        public long InfoID { get; set; }
        /// <summary>
        /// 借出状态
        /// </summary>
        public bool IsLeased { get; set; }

        private Book() { }

        /// <summary>
        /// 书本构造函数
        /// </summary>
        /// <param name="iid">书籍编号</param>
        public Book(long iid)
        {
            this.BookID = 0;
            this.InfoID = iid;
            this.IsLeased = false;
        }

        /// <summary>
        /// 通过书本编号获取书本对象
        /// </summary>
        /// <param name="id">书本编号</param>
        /// <param name="conn">数据库连接</param>
        /// <returns>书本对象</returns>
        public static Book GetBookByID(long id, SqlConnection conn)
        {
            string sql = string.Format("SELECT * FROM Books WHERE BookID={0}", id);

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            Book b = null;
            if (dr.Read())
            {
                b = new Book();
                b.BookID = Convert.ToInt64(dr["BookID"]);
                b.InfoID = Convert.ToInt64(dr["InfoID"]);
                b.IsLeased = Convert.ToBoolean(dr["IsLeased"]);
            }
            return b;
        }

        /// <summary>
        /// 通过书籍编号获取相同的书本
        /// </summary>
        /// <param name="iid">书籍编号</param>
        /// <param name="conn">数据库连接</param>
        /// <returns>书本列表</returns>
        public static List<Book> GetBooksByInfoID(long iid, SqlConnection conn)
        {
            List<Book> books = new List<Book>();
            string sql = string.Format("SELECT * FROM Books WHERE InfoID={0}", iid);

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Book b = new Book();
                b.BookID = Convert.ToInt64(dr["BookID"]);
                b.InfoID = Convert.ToInt64(dr["InfoID"]);
                b.IsLeased = Convert.ToBoolean(dr["IsLeased"]);

                books.Add(b);
            }

            dr.Close();

            return books;
        }

        /// <summary>
        /// 通过书本编号删除书本
        /// </summary>
        /// <param name="id">书本编号</param>
        /// <param name="conn">连接</param>
        /// <returns>操作结果</returns>
        public static int DelBookByID(long id, SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("decalre @result int;exec @result=proc_del_book {0};select @result", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = (int)cmd.ExecuteScalar();

            return result;
        }


        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            int result = 0;
            if (BookID != 0)
            {
                throw new Exception("ID不为0，不能插入");
            }

            string sql = "decalre @bid long;exec proc_add_book @iid,@bid out;select @bid";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlParameter paramInfoID = new SqlParameter("@iid", SqlDbType.BigInt);
            paramInfoID.Value = InfoID;
            cmd.Parameters.Add(paramInfoID);
            object obj = cmd.ExecuteScalar();

            if (!obj.Equals(DBNull.Value))
            {
                BookID = (long)obj;
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("decalre @result int;exec @result=proc_del_book {0};select @result", BookID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = (int)cmd.ExecuteScalar();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE Books");
            sb.AppendLine(string.Format("SET InfoID={0},IsLeased={1}", InfoID, IsLeased ? 1 : 0));
            sb.AppendLine(string.Format("WHERE [BookID]={0}", BookID));
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
