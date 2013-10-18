using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    public class Record : IDBOperate
    {
        public long RecordID { get; private set; }
        public long UID { get; set; }
        public long BookID { get; set; }
        public DateTime LeaseDate { get; set; }
        public DateTime ReturnDate { get; set; }

        private Record() { }

        public Record(long uid, long bid, DateTime ld)
        {
            RecordID = 0;
            UID = uid;
            BookID = bid;
            LeaseDate = ld;
            ReturnDate = DateTime.Now;
        }

        public static Record GetRecordByID(long id, SqlConnection conn)
        {
            Record r = null;

            string sql = string.Format("SELECT * FROM Records WHERE RecordID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                r = new Record();
                r.RecordID = Convert.ToInt64(dr["RecordID"]);
                r.UID = Convert.ToInt64(dr["UID"]);
                r.BookID = Convert.ToInt64(dr["BookID"]);
                r.LeaseDate = Convert.ToDateTime(dr["LeaseDate"]);
                r.ReturnDate = Convert.ToDateTime(dr["ReturnDate"]);
            }

            dr.Close();

            return r;
        }

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.RecordID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;

            string sql = string.Format("INSERT INTO Records VALUES({0},{1},@ld,@rd);SELECT SCOPE_IDENTITY()", UID, BookID);
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramLeaseDate = new SqlParameter("@ld", SqlDbType.DateTime);
            SqlParameter paramReturnDate = new SqlParameter("@rd", SqlDbType.DateTime);

            paramLeaseDate.Value = LeaseDate;
            paramReturnDate.Value = ReturnDate;

            cmd.Parameters.Add(paramLeaseDate);
            cmd.Parameters.Add(paramReturnDate);

            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                RecordID = Convert.ToInt64(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("DELETE Records WHERE RecordID={0}", RecordID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE Records SET [UID]={0},BookID={1},LeaseDate=@ld,ReturnDate=@rd WHERE RecordID={2}", UID, BookID, RecordID);
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramLeaseDate = new SqlParameter("@ld", SqlDbType.DateTime);
            SqlParameter paramReturnDate = new SqlParameter("@rd", SqlDbType.DateTime);

            paramLeaseDate.Value = LeaseDate;
            paramReturnDate.Value = ReturnDate;

            cmd.Parameters.Add(paramLeaseDate);
            cmd.Parameters.Add(paramReturnDate);

            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
