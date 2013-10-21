using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    public class LibraryHelper
    {
        public static Order PreOrderToOrder(PreOrder preOrder, SqlConnection conn)
        {
            Order o = null;
            string sql = "declare @oid bigint;exec proc_pre_into_order @pid,@ld,@oid out;select @oid";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramPreOrderID = new SqlParameter("@pid", SqlDbType.BigInt);
            SqlParameter paramLeaseDate = new SqlParameter("@ld", SqlDbType.DateTime);

            paramPreOrderID.Value = preOrder.PreOrderID;
            paramLeaseDate.Value = DateTime.Now;

            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value) && !obj.Equals(0))
            {
                o = Order.GetOrderByID((long)obj, conn);
            }

            return o;
        }

        public static Record ReturnBook(long bookID, SqlConnection conn)
        {
            Record r = null;

            string sql = string.Format("declare @rid bigint;exec proc_return_book {0},@rd,@rid out;select @rid", bookID);
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramReturnDate = new SqlParameter("@rd", SqlDbType.DateTime);
            paramReturnDate.Value = DateTime.Now;
            cmd.Parameters.Add(paramReturnDate);

            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value) && !obj.Equals(0))
            {
                r = Record.GetRecordByID((long)obj, conn);
            }

            return r;
        }

        public static Record ReturnBook(Book book, SqlConnection conn)
        {
            return ReturnBook(book.BookID, conn);
        }

        public static List<BookInfo> GetTopXBookInfos(int x, SqlConnection conn)
        {
            List<BookInfo> books = new List<BookInfo>();

            string sql = string.Format("exec proc_top_bookinfo {0}", x);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                books.Add(BookInfo.GetBookInfoByID(dr.GetInt64(0), conn));
            }

            return books;
        }

        public static int ValidateLogin(string username, string password, SqlConnection conn)
        {
            User u = User.GetUserByName(username, conn);

            string sql = string.Format("declare @v bit;exec proc_validate_user @uid,@pw,@v out;select @v");
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUID = new SqlParameter("@uid", SqlDbType.BigInt);
            SqlParameter paramPassword = new SqlParameter("@pw", SqlDbType.VarChar);

            cmd.Parameters.Add(paramUID);
            cmd.Parameters.Add(paramPassword);

            if ((bool)cmd.ExecuteScalar())
            {
                return u.UserGroupID;
            }

            return 0;
        }

    }
}
