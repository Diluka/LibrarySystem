using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
   public  class BookBrief:IDBOperate
    {
       public long InfoID { get; private set; }
       public string BriefText { get; set; }

       private BookBrief() { }

       public BookBrief(long iid,string text)
       {
           InfoID = iid;
           BriefText = text;
       }

       public static BookBrief GetBookBriefByID(long id, SqlConnection conn)
       {
           BookBrief b = null;
           string sql = string.Format("SELECT * FROM BookBrief WHERE InfoID={0}",id);
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader dr = cmd.ExecuteReader();

           if (dr.Read())
           {
               b = new BookBrief();
               b.InfoID = Convert.ToInt64(dr["InfoID"]);
               b.BriefText = dr["BriefText"].ToString();
           }

           dr.Close();

           return b;
       }

       #region IDBOperate 成员

       int IDBOperate.Insert(SqlConnection conn)
       {
           int result = 0;
           string sql = string.Format("INSERT INTO BookBrief VALUES({0},'{1}')",InfoID,BriefText);
           SqlCommand cmd = new SqlCommand(sql, conn);
           result = cmd.ExecuteNonQuery();

           return result;
       }

       int IDBOperate.Delete(SqlConnection conn)
       {
           int result = 0;
           string sql = string.Format("DELETE BookBrief WHERE InfoID={0}", InfoID);
           SqlCommand cmd = new SqlCommand(sql, conn);
           result = cmd.ExecuteNonQuery();

           return result;
       }

       int IDBOperate.Update(SqlConnection conn)
       {
           int result = 0;
           string sql = string.Format("UPDATE BookBrief SET BriefText='{1}' WHERE InfoID={0}", InfoID, BriefText);
           SqlCommand cmd = new SqlCommand(sql, conn);
           result = cmd.ExecuteNonQuery();

           return result;
       }

       #endregion
    }
}
