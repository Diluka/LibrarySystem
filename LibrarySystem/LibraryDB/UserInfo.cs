using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    public enum GenderType
    {
        未指定 = -1, 女 = 0, 男 = 1
    }
    public class UserInfo : IDBOperate
    {
        public long UID { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public GenderType Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegTime { get; set; }

        private UserInfo() { }

        public UserInfo(long uid, string name, int? age, GenderType gen, string phone, string email, string addr)
        {
            UID = uid;
            Name = name;
            Age = age;
            Gender = gen;
            Phone = phone;
            Email = email;
            Address = addr;
            RegTime = DateTime.Now;
        }

        public static UserInfo GetUserInfoByID(long id, SqlConnection conn)
        {
            UserInfo u = null;


            string sql = string.Format("SELECT * FROM UserInfo WHERE [UID]={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                u = new UserInfo();
                u.UID = Convert.ToInt64(dr["UID"]);
                u.Name = dr["Name"].ToString();
                u.Age = dr["Age"].Equals(DBNull.Value) ? (int?)null : Convert.ToInt32(dr["Age"]);
                u.Gender = dr["Gender"].Equals(DBNull.Value) ? GenderType.未指定 : Convert.ToInt32(dr["Gender"]) == 1 ? GenderType.男 : GenderType.女;
                u.Phone = dr["Phone"].Equals(DBNull.Value) ? null : dr["Phone"].ToString();
                u.Email = dr["Email"].Equals(DBNull.Value) ? null : dr["Email"].ToString();
                u.Address = dr["Address"].Equals(DBNull.Value) ? null : dr["Address"].ToString();
                u.RegTime = Convert.ToDateTime(dr["RegTime"]);
            }

            dr.Close();

            return u;
        }

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("INSERT INTO UserInfo VALUES(@uid,@name,@age,@gen,@phone,@email,@addr,@rt)");
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUID = new SqlParameter("@uid", SqlDbType.BigInt);
            SqlParameter paramName = new SqlParameter("@name", SqlDbType.NVarChar);
            SqlParameter paramAge = new SqlParameter("@age", SqlDbType.Int);
            SqlParameter paramGender = new SqlParameter("@gen", SqlDbType.Bit);
            SqlParameter paramPhone = new SqlParameter("@phone", SqlDbType.VarChar);
            SqlParameter paramEmail = new SqlParameter("@email", SqlDbType.VarChar);
            SqlParameter paramAddr = new SqlParameter("@addr", SqlDbType.NVarChar);
            SqlParameter paramRegTime = new SqlParameter("@rt", SqlDbType.DateTime);

            paramUID.Value = UID;
            paramName.Value = Name;
            paramAge.Value = Age ?? (object)DBNull.Value;
            paramGender.Value = Gender == GenderType.男 ? 1 : Gender == GenderType.女 ? 0 : (object)DBNull.Value;
            paramPhone.Value = Phone ?? (object)DBNull.Value;
            paramEmail.Value = Email ?? (object)DBNull.Value;
            paramAddr.Value = Address ?? (object)DBNull.Value;
            paramRegTime.Value = RegTime;

            cmd.Parameters.Add(paramUID);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramAge);
            cmd.Parameters.Add(paramGender);
            cmd.Parameters.Add(paramPhone);
            cmd.Parameters.Add(paramEmail);
            cmd.Parameters.Add(paramAddr);
            cmd.Parameters.Add(paramRegTime);

            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("DELETE UserInfo WHERE [UID]={0}", UID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE UserInfo SET Name=@name,Age=@age,Gender=@gen,Phone=@phone,Email=@email,Address=@addr,RegTime=@rt WHERE [UID]={0}", UID);
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramName = new SqlParameter("@name", SqlDbType.NVarChar);
            SqlParameter paramAge = new SqlParameter("@age", SqlDbType.Int);
            SqlParameter paramGender = new SqlParameter("@gen", SqlDbType.Bit);
            SqlParameter paramPhone = new SqlParameter("@phone", SqlDbType.VarChar);
            SqlParameter paramEmail = new SqlParameter("@email", SqlDbType.VarChar);
            SqlParameter paramAddr = new SqlParameter("@addr", SqlDbType.NVarChar);
            SqlParameter paramRegTime = new SqlParameter("@rt", SqlDbType.DateTime);

            paramName.Value = Name;
            paramAge.Value = Age ?? (object)DBNull.Value;
            paramGender.Value = Gender == GenderType.男 ? 1 : Gender == GenderType.女 ? 0 : (object)DBNull.Value;
            paramPhone.Value = Phone ?? (object)DBNull.Value;
            paramEmail.Value = Email ?? (object)DBNull.Value;
            paramAddr.Value = Address ?? (object)DBNull.Value;
            paramRegTime.Value = RegTime;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramAge);
            cmd.Parameters.Add(paramGender);
            cmd.Parameters.Add(paramPhone);
            cmd.Parameters.Add(paramEmail);
            cmd.Parameters.Add(paramAddr);
            cmd.Parameters.Add(paramRegTime);

            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
