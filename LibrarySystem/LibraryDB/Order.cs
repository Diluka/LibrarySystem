using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    public class Order : IDBOperate
    {
        public long OrderID { get; private set; }
        public long UID { get; set; }
        public long BookID { get; set; }
        public DateTime LeaseDate { get; set; }

        private Order() { }

        public Order(long uid, long bid)
        {
            OrderID = 0;
            UID = uid;
            BookID = bid;
            LeaseDate = DateTime.Now;
        }

        public static Order GetOrderByID(long id, SqlConnection conn)
        {
            Order o = null;

            string sql = string.Format("SELECT * FROM Orders WHERE OrderID={0}", id);

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                o = new Order();
                o.OrderID = Convert.ToInt64(dr["OrderID"]);
                o.UID = Convert.ToInt64(dr["UID"]);
                o.BookID = Convert.ToInt64(dr["BookID"]);
                o.LeaseDate = Convert.ToDateTime(dr["LeaseDate"]);
            }

            dr.Close();

            return o;
        }

        /// <summary>
        /// 获取指定用户的所有订单
        /// </summary>
        /// <param name="uid">用户UID</param>
        /// <param name="conn">连接</param>
        /// <returns>订单列表</returns>
        public static List<Order> GetOrdersByUID(long uid, SqlConnection conn)
        {
            string sql = string.Format("SELECT * FROM Orders WHERE [UID]={0}", uid);
            List<Order> orders = new List<Order>();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Order o = new Order();
                o.OrderID = Convert.ToInt64(dr["OrderID"]);
                o.UID = Convert.ToInt64(dr["UID"]);
                o.BookID = Convert.ToInt64(dr["BookID"]);
                o.LeaseDate = Convert.ToDateTime(dr["LeaseDate"]);

                orders.Add(o);
            }

            dr.Close();

            return orders;
        }

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.OrderID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;
            string sql = "declare @oid bigint;exec proc_lease_book @uid,@bid,@ld,@oid out;select @oid";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUID = new SqlParameter("@uid", SqlDbType.BigInt);
            SqlParameter paramBookID = new SqlParameter("@bid", SqlDbType.BigInt);
            SqlParameter paramLeaseDate = new SqlParameter("@ld", SqlDbType.DateTime);

            paramUID.Value = UID;
            paramBookID.Value = BookID;
            paramLeaseDate.Value = LeaseDate;

            cmd.Parameters.Add(paramUID);
            cmd.Parameters.Add(paramBookID);
            cmd.Parameters.Add(paramLeaseDate);

            object obj = cmd.ExecuteScalar();

            if (!obj.Equals(DBNull.Value) && !obj.Equals(0))
            {
                OrderID = Convert.ToInt64(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("exec proc_del_order {0}", OrderID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE Orders SET [UID]=@uid,BookID=@bid,LeaseDate=@ld WHERE OrderID={0}", OrderID);

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUID = new SqlParameter("@uid", SqlDbType.BigInt);
            SqlParameter paramBookID = new SqlParameter("@bid", SqlDbType.BigInt);
            SqlParameter paramLeaseDate = new SqlParameter("@ld", SqlDbType.DateTime);

            paramUID.Value = UID;
            paramBookID.Value = BookID;
            paramLeaseDate.Value = LeaseDate;

            cmd.Parameters.Add(paramUID);
            cmd.Parameters.Add(paramBookID);
            cmd.Parameters.Add(paramLeaseDate);

            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
