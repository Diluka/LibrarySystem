using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    public class Category : IDBOperate
    {
        public int CatID { get; private set; }
        public string CategoryName { get; set; }
        public int MaxDay { get; set; }

        private Category() { }

        public Category(string name, int day)
        {
            this.CatID = 0;
            this.CategoryName = name;
            this.MaxDay = day;
        }

        public static Category GetCategoryByID(int id, SqlConnection conn)
        {
            Category c = null;

            string sql = string.Format("SELECT * FROM Categories WHERE CatID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                c = new Category();
                c.CatID = Convert.ToInt32(dr["CatID"]);
                c.CategoryName = dr["Category"].ToString();
            }

            dr.Close();

            return c;
        }

        public static List<Category> GetAllCategories(SqlConnection conn)
        {
            List<Category> categories = new List<Category>();

            string sql = "select * from categories";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Category c = new Category();
                c.CatID = Convert.ToInt32(dr["CatID"]);
                c.CategoryName = dr["Category"].ToString();
                categories.Add(c);
            }

            dr.Close();

            return categories;
        }

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.CatID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;

            string sql = string.Format("INSERT INTO Categories VALUES('{0}',{1});SELECT SCOPE_IDENTITY()", CategoryName, MaxDay);
            SqlCommand cmd = new SqlCommand(sql, conn);
            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                CatID = Convert.ToInt32(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("exec proc_del_category {0}", CatID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE Categories SET Category='{0}' WHERE CatID={1}", CategoryName, CatID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
