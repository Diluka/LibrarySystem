using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    /// <summary>
    /// 图书馆数据库操作辅助工具
    /// </summary>
    public class LibraryHelper
    {
        /// <summary>
        /// 将预约转换成订单
        /// </summary>
        /// <param name="preOrder">预约</param>
        /// <param name="conn">数据库连接</param>
        /// <returns>订单</returns>
        public static Order PreOrderToOrder(PreOrder preOrder, SqlConnection conn)
        {
            Order o = null;
            string sql = "declare @oid bigint;exec proc_pre_into_order @pid,@ld,@oid out;select @oid";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramPreOrderID = new SqlParameter("@pid", SqlDbType.BigInt);
            SqlParameter paramLeaseDate = new SqlParameter("@ld", SqlDbType.DateTime);

            paramPreOrderID.Value = preOrder.PreOrderID;
            paramLeaseDate.Value = DateTime.Now;

            cmd.Parameters.Add(paramPreOrderID);
            cmd.Parameters.Add(paramLeaseDate);

            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value) && !obj.Equals(0))
            {
                o = Order.GetOrderByID((long)obj, conn);
            }

            return o;
        }

        /// <summary>
        /// 还书
        /// </summary>
        /// <param name="bookID">书号</param>
        /// <param name="conn">连接</param>
        /// <returns>借书记录</returns>
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

        /// <summary>
        /// 还书
        /// </summary>
        /// <param name="book">书籍</param>
        /// <param name="conn">连接</param>
        /// <returns>借书记录</returns>
        public static Record ReturnBook(Book book, SqlConnection conn)
        {
            return ReturnBook(book.BookID, conn);
        }

        /// <summary>
        /// 获取借阅次数最多的X本图书信息
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="conn">连接</param>
        /// <returns>书籍信息列表</returns>
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

        /// <summary>
        /// 验证登陆
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="conn">连接</param>
        /// <returns>用户组编号，失败为0</returns>
        public static int ValidateLogin(string username, string password, SqlConnection conn)
        {
            User u = User.GetUserByName(username, conn);

            if (u == null)//用户不存在
            {
                return 0;
            }

            string sql = string.Format("declare @v bit;exec proc_validate_user @uid,@pw,@v out;select @v");
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter paramUID = new SqlParameter("@uid", SqlDbType.BigInt);
            SqlParameter paramPassword = new SqlParameter("@pw", SqlDbType.VarChar);

            paramUID.Value = u.Uid;
            paramPassword.Value = password;

            cmd.Parameters.Add(paramUID);
            cmd.Parameters.Add(paramPassword);

            if ((bool)cmd.ExecuteScalar())
            {
                return u.UserGroupID;
            }

            return 0;
        }

        /// <summary>
        /// 验证登陆
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="conn">连接</param>
        /// <returns>用户分组信息</returns>
        public static UserGroupInfo ValidateLogin2(string username, string password, SqlConnection conn)
        {
            int groupID = ValidateLogin(username, password, conn);
            return UserGroupInfo.GetUserGroupInfoByID(groupID, conn);
        }

    }
}
