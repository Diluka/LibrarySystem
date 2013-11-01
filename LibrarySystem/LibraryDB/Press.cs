using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    public class Press : IDBOperate
    {
        public int PressID { get; private set; }
        public string PressName { get; set; }

        private Press() { }

        public Press(string name)
        {
            this.PressID = 0;
            this.PressName = name;
        }

        public static Press GetPressByID(int id, SqlConnection conn)
        {
            Press p = null;

            string sql = string.Format("SELECT * FROM Presses WHERE PressID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                p = new Press();
                p.PressID = Convert.ToInt32(dr["PressID"]);
                p.PressName = dr["PressName"].ToString();
            }

            dr.Close();

            return p;
        }

        /// <summary>
        /// 获取所有出版社
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <returns>出版社列表</returns>
        public static List<Press> GetAllPresses(SqlConnection conn)
        {
            List<Press> presses = new List<Press>();

            string sql = "select * from presses";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Press p = new Press();
                p.PressID = Convert.ToInt32(dr["PressID"]);
                p.PressName = dr["PressName"].ToString();

                presses.Add(p);
            }

            dr.Close();

            return presses;
        }


        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.PressID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;

            string sql = string.Format("INSERT INTO Presses VALUES('{0}');SELECT SCOPE_IDENTITY()", PressName);
            SqlCommand cmd = new SqlCommand(sql, conn);
            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                PressID = Convert.ToInt32(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("exec proc_del_press {0}", PressID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE Presses SET PressName='{0}' WHERE PressID={1}", PressName, PressID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
