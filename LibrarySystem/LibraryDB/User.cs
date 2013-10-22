﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User : IDBOperate
    {
        private long uid;

        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid
        {
            get { return uid; }
            private set { uid = value; }
        }
        private string username;

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get { return username; }
            private set { username = value; }
        }
        private string password;

        private int userGroupID;

        /// <summary>
        /// 用户组ID
        /// </summary>
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

        /// <summary>
        /// 通过用户UID获取
        /// </summary>
        /// <param name="id">UID</param>
        /// <param name="conn"></param>
        /// <returns>用户对象</returns>
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

        /// <summary>
        /// 通过用户名获取
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static User GetUserByName(string name, SqlConnection conn)
        {
            string sql = string.Format("SELECT * FROM Users WHERE Username='{0}'", name);
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

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <param name="conn"></param>
        /// <returns>结果</returns>
        public int ChangePassword(string newPassword, SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("exec proc_change_pwd @uid,@pw");
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUID = new SqlParameter("@uid", SqlDbType.BigInt);
            SqlParameter paramPassword = new SqlParameter("@pw", SqlDbType.VarChar);

            paramUID.Value = uid;
            paramPassword.Value = newPassword;

            cmd.Parameters.Add(paramUID);
            cmd.Parameters.Add(paramPassword);

            result = cmd.ExecuteNonQuery();

            return result;

        }


        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.uid != 0)
            {
                throw new Exception("ID不为零，不能插入");
            }
            int result = 0;

            string sql = "declare @id bigint;exec proc_add_user @un,@pw,@gid,@id out;select @id";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUsername = new SqlParameter("@un", SqlDbType.VarChar);
            SqlParameter paramPassword = new SqlParameter("@pw", SqlDbType.VarChar);
            SqlParameter paramUserGroupID = new SqlParameter("@gid", SqlDbType.Int);

            paramUsername.Value = username;
            paramPassword.Value = password;
            paramUserGroupID.Value = userGroupID;

            cmd.Parameters.Add(paramUsername);
            cmd.Parameters.Add(paramPassword);
            cmd.Parameters.Add(paramUserGroupID);

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
            sb.AppendLine(string.Format("SET UserGroupID={0}", userGroupID));
            sb.AppendLine(string.Format("WHERE [UID]={0}", uid));
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
