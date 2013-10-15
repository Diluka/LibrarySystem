using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    public class UserGroupInfo : IDBOperate
    {
        public int UGID { get; private set; }
        public string GroupName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVIP { get; set; }
        private int maxOrders;
        public int MaxOrders
        {
            get
            {
                return maxOrders;
            }
            set
            {
                if (value <= 0) { maxOrders = 3; }
                else
                {
                    maxOrders = value;
                }
            }
        }

        private UserGroupInfo() { }

        public UserGroupInfo(string name, bool admin, bool vip, int max)
        {
            UGID = 0;
            GroupName = name;
            IsAdmin = admin;
            IsVIP = vip;
            MaxOrders = max;
        }

        public static UserGroupInfo GetUserGroupInfoByID(int id,SqlConnection conn)
        {
            UserGroupInfo u = null;

            string sql = string.Format("SELECT * FROM UserGroupInfo WHERE UGID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                u = new UserGroupInfo();
                u.UGID = Convert.ToInt32(dr["UGID"]);
                u.GroupName = dr["GroupName"].ToString();
                u.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
                u.IsVIP = Convert.ToBoolean(dr["IsVIP"]);
                u.MaxOrders = Convert.ToInt32(dr["MaxOrders"]);
            }

            dr.Close();

            return u;
        }

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.UGID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;

            string sql = string.Format("INSERT INTO UserGroupInfo VALUES('{0}',{1},{2},{3});SELECT SCOPE_IDENTITY()", GroupName, IsAdmin ? 1 : 0, IsVIP ? 1 : 0, MaxOrders);
            SqlCommand cmd = new SqlCommand(sql, conn);
            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                UGID = Convert.ToInt32(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("DELETE UserGroupInfo WHERE UGID={0}", UGID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE UserGroupInfo SET GroupName='{0}',IsAdmin={2},IsVIP={3},MaxOrders={4} WHERE UGID={1}", GroupName, UGID, IsAdmin ? 1 : 0, IsVIP ? 1 : 0, MaxOrders);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
