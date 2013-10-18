using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    public class Book : IDBOperate
    {
        public long BookID { get; private set; }
        public long InfoID { get; set; }
        public bool IsLeased { get; set; }

        private Book() { }
        public Book(long iid)
        {
            this.BookID = 0;
            this.InfoID = iid;
            this.IsLeased = false;
        }

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

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.BookID != 0)
            {
                throw new Exception("ID不为零，不能插入");
            }
            int result = 0;

            string sql = string.Format("INSERT INTO Books VALUES({0},default);SELECT SCOPE_IDENTITY()", InfoID);
            SqlCommand cmd = new SqlCommand(sql, conn);

            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                BookID = Convert.ToInt64(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DELETE Books");
            sb.AppendLine(string.Format("WHERE [BookID]={0}", BookID));
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            result = cmd.ExecuteNonQuery();

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
