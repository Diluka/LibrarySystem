using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    /// <summary>
    /// 作者类
    /// </summary>
    public class Author : IDBOperate
    {
        /// <summary>
        /// 作者ID
        /// </summary>
        public int AuthorID { get; private set; }
        /// <summary>
        /// 作者名
        /// </summary>
        public string AuthorName { get; set; }

        private Author() { }

        /// <summary>
        /// 作者构造函数
        /// </summary>
        /// <param name="name">作者名</param>
        public Author(string name)
        {
            this.AuthorID = 0;
            this.AuthorName = name;
        }

        /// <summary>
        /// 通过作者ID获取作者对象
        /// </summary>
        /// <param name="id">作者ID</param>
        /// <param name="conn">数据库连接</param>
        /// <returns>作者对象</returns>
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

        /// <summary>
        /// 获取所有作者
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <returns>所有作者列表</returns>
        public static List<Author> GetAllAuthors(SqlConnection conn)
        {
            List<Author> authors = new List<Author>();

            string sql = "select * from authors";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Author a = new Author();
                a.AuthorID = Convert.ToInt32(dr["AuthorID"]);
                a.AuthorName = dr["AuthorName"].ToString();

                authors.Add(a);
            }

            dr.Close();

            return authors;
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

            string sql = string.Format("exec proc_del_author {0}", AuthorID);
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
