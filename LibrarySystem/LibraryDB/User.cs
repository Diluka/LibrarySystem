using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    public class User : IDBOperate
    {
        private long uid;

        public long Uid
        {
            get { return uid; }
            private set { uid = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            private set { username = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int userGroupID;

        public int UserGroupID
        {
            get { return userGroupID; }
            set { userGroupID = value; }
        }

        private User() { }
        public User(string username, string password, int userGroupID)
        {
            this.uid = 0;
            this.username = username;
            this.password = password;
            this.userGroupID = userGroupID;
        }

        public string GetPasswordEncryption()
        {
            return EncryptionHelper.ToSHA1(password);
        }

        public static User GetUserByID(long id, SqlConnection conn)
        {
            string sql = string.Format("SELECT * FROM Users WHERE [UID]={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            User u = null;
            if (dr.Read())
            {
                u = new User();
                u.uid = Convert.ToInt64(dr["UID"]);
                u.username = dr["Username"].ToString();
                u.password = dr["Password"].ToString();
                u.userGroupID = Convert.ToInt32(dr["UserGroupID"]);
            }
            dr.Close();
            return u;
        }


        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.uid != 0)
            {
                throw new Exception("ID不为零，不能插入");
            }
            int result = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Users");
            sb.AppendLine(string.Format("VALUES('{0}','{1}',{2})", username, GetPasswordEncryption(), userGroupID));
            sb.AppendLine("SELECT SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                uid = Convert.ToInt64(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DELETE Users");
            sb.AppendLine(string.Format("WHERE [UID]={0}", uid));
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE Users");
            sb.AppendLine(string.Format("SET Username='{0}',Password='{1}',UserGroupID={2}", username, GetPasswordEncryption(), userGroupID));
            sb.AppendLine(string.Format("WHERE [UID]={0}", uid));
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
