using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    public class PreOrder : IDBOperate
    {
        public long PreOrderID { get; private set; }
        public long UID { get; set; }
        public long InfoID { get; set; }
        public DateTime PreOrderDate { get; set; }

        private PreOrder() { }

        public PreOrder(long uid, long iid)
        {
            this.PreOrderID = 0;
            this.UID = uid;
            this.InfoID = iid;
            this.PreOrderDate = DateTime.Now;
        }

        public static PreOrder GetPreOrderByID(long id, SqlConnection conn)
        {
            PreOrder p = null;

            string sql = string.Format("SELECT * FROM PreOrders WHERE PreOrderID={0}", id);

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                p = new PreOrder();
                p.PreOrderID = Convert.ToInt64(dr["PreOrderID"]);
                p.UID = Convert.ToInt64(dr["UID"]);
                p.InfoID = Convert.ToInt64(dr["InfoID"]);
                p.PreOrderDate = Convert.ToDateTime(dr["PreOrderDate"]);
            }

            dr.Close();

            return p;
        }

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.PreOrderID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;
            string sql = "INSERT INTO PreOrders VALUES(@uid,@iid,@pd);SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUID = new SqlParameter("@uid", SqlDbType.BigInt);
            SqlParameter paramInfoID = new SqlParameter("@iid", SqlDbType.BigInt);
            SqlParameter paramPreOrderDate = new SqlParameter("@pd", SqlDbType.DateTime);

            paramUID.Value = UID;
            paramInfoID.Value = InfoID;
            paramPreOrderDate.Value = PreOrderDate;

            cmd.Parameters.Add(paramUID);
            cmd.Parameters.Add(paramInfoID);
            cmd.Parameters.Add(paramPreOrderDate);

            object obj = cmd.ExecuteScalar();

            if (!obj.Equals(DBNull.Value))
            {
                PreOrderID = Convert.ToInt64(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("DELETE PreOrders WHERE PreOrderID={0}", PreOrderID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;
            string sql = string.Format("UPDATE PreOrders SET [UID]=@uid,InfoID=@iid,PreOrderDate=@pd WHERE PreOrderID={0}", PreOrderID);
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUID = new SqlParameter("@uid", SqlDbType.BigInt);
            SqlParameter paramInfoID = new SqlParameter("@iid", SqlDbType.BigInt);
            SqlParameter paramPreOrderDate = new SqlParameter("@pd", SqlDbType.DateTime);

            paramUID.Value = UID;
            paramInfoID.Value = InfoID;
            paramPreOrderDate.Value = PreOrderDate;

            cmd.Parameters.Add(paramUID);
            cmd.Parameters.Add(paramInfoID);
            cmd.Parameters.Add(paramPreOrderDate);

            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
