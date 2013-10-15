using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    public enum GenderType
    {
        女=0,男=1
    }
   public  class UserInfo:IDBOperate
    {
       public long UID { get; set; }
       public string Name { get; set; }
       public int? Age { get; set; }
       public GenderType? Gender { get; set; }
       public string Phone { get; set; }
       public string Email { get; set; }
       public string Address { get; set; }
       public DateTime RegTime { get; set; }

       private UserInfo() { }

       public UserInfo(long uid,string name, int? age, GenderType? gen, string phone, string email, string addr)
       {
           UID = uid;
           Age = age;
           Gender = gen;
           Phone = phone;
           Email = email;
           Address = addr;
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
               u.Age = dr["Age"].Equals(DBNull.Value)?(int?)null:Convert.ToInt32(dr["Age"]);
               u.Gender = dr["Gender"].Equals(DBNull.Value) ? (GenderType?)null : Convert.ToInt32(dr["Gender"]) == 1 ? GenderType.男 : GenderType.女;
               u.Phone = dr["Phone"].Equals(DBNull.Value)?null:dr["Phone"].ToString();
               u.Email = dr["Email"].Equals(DBNull.Value) ? null : dr["Email"].ToString();
               u.Address = dr["Address"].Equals(DBNull.Value) ? null : dr["Address"].ToString();
               u.RegTime = Convert.ToDateTime(dr["RegDate"]);
           }

           dr.Close();

           return u;
       }

       #region IDBOperate 成员

       int IDBOperate.Insert(SqlConnection conn)
       {
           int result = 0;

           string sql = string.Format("INSERT INTO UserInfo VALUES({0},'{1}',{2},{3},{4},{5},{6},default);SELECT RegDate FROM UserInfo WHERE UID=SCOPE_IDENTITY()",UID,Name,Age??(object)"null",Gender==null?(object)"null":Gender==GenderType.男?1:0,Phone==null?"null":"'"+Phone+"'",Email==null?"null":"'"+Email+"'",Address==null?"null":"'"+Address+"'");
           SqlCommand cmd = new SqlCommand(sql, conn);
           object obj = cmd.ExecuteScalar();
           if (!obj.Equals(DBNull.Value))
           {
               RegTime = Convert.ToDateTime(obj);
               result = 1;
           }

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

           string sql = string.Format("UPDATE UserInfo SET Name='{1}',Age={2},Gender={3},Phone={4},Email={5},Address={6},RegDate='{7}' WHERE [UID]={0}", UID, Name, Age ?? (object)"null", Gender == null ? (object)"null" : Gender == GenderType.男 ? 1 : 0, Phone == null ? "null" : "'" + Phone + "'", Email == null ? "null" : "'" + Email + "'", Address == null ? "null" : "'" + Address + "'", RegTime.ToString("yyyy-MM-dd hh:mm:ss"));
           SqlCommand cmd = new SqlCommand(sql, conn);
           result = cmd.ExecuteNonQuery();

           return result;
       }

       #endregion
    }
}
