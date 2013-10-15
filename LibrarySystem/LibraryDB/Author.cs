using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    public class Author : IDBOperate
    {
        public int AuthorID { get; private set; }
        public string AuthorName { get; set; }

        private Author() { }

        public Author(string name)
        {
            this.AuthorID = 0;
            this.AuthorName = name;
        }

        public static Author GetAuthorByID(int id, SqlConnection conn)
        {
            Author a = null;

            string sql = string.Format("SELECT * FROM Authors WHERE AuthorID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                a = new Author();
                a.AuthorID = Convert.ToInt32(dr["AuthorID"]);
                a.AuthorName = dr["AuthorName"].ToString();
            }

            dr.Close();

            return a;
        }



        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.AuthorID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;

            string sql = string.Format("INSERT INTO Authors VALUES('{0}');SELECT SCOPE_IDENTITY()", AuthorName);
            SqlCommand cmd = new SqlCommand(sql, conn);
            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                AuthorID = Convert.ToInt32(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("DELETE Authors WHERE AuthorID={0}", AuthorID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE Authors SET AuthorName='{0}' WHERE AuthorID={1}", AuthorName, AuthorID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
