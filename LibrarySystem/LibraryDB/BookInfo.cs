using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDB
{
    public class BookInfo : IDBOperate
    {
        public long InfoID { get; private set; }
        public int? CatID { get; set; }
        public string Title { get; set; }
        public char Alphabet { get; set; }
        public string ISBN { get; set; }
        public int? AuthorID { get; set; }
        public int? PressID { get; set; }
        public DateTime? PressDate { get; set; }
        public decimal? Price { get; set; }


        private int total;
        public int Total
        {
            get
            {
                return total;
            }
            set
            {
                if (value < 0)
                {
                    total = 0;
                }
                else
                {
                    total = value;
                }
            }
        }
        private int remain;
        public int Remain
        {
            get
            {
                return remain;
            }
            set
            {
                if (value < 0)
                {
                    remain = 0;
                }
                else
                {
                    remain = value;
                }
            }
        }

        private BookInfo() { }

        public BookInfo(int? cid, string title, char alpha, string isbn, int? aid, int? pid, DateTime? pdate, decimal? price)
        {
            this.InfoID = 0;
            this.CatID = cid;
            this.Title = title;
            this.Alphabet = alpha;
            this.ISBN = isbn;
            this.AuthorID = aid;
            this.PressID = pid;
            this.PressDate = pdate;
            this.Price = price;
        }

        public static BookInfo GetBookInfoByID(long id, SqlConnection conn)
        {
            BookInfo b = null;

            string sql = string.Format("SELECT * FROM BookInfo WHERE InfoID={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                b = new BookInfo();
                b.InfoID = Convert.ToInt64(dr["InfoID"]);
                b.Title = dr["Title"].ToString();
                b.CatID = dr["CatID"].Equals(DBNull.Value) ? (int?)null : Convert.ToInt32(dr["CatID"]);
                b.Alphabet = Convert.ToChar(dr["Alphabet"]);
                b.ISBN = dr["ISBN"].Equals(DBNull.Value) ? null : dr["ISBN"].ToString();
                b.AuthorID = dr["AuthorID"].Equals(DBNull.Value) ? (int?)null : Convert.ToInt32(dr["AuthorID"]);
                b.PressID = dr["PressID"].Equals(DBNull.Value) ? (int?)null : Convert.ToInt32(dr["PressID"]);
                b.PressDate = dr["PressDate"].Equals(DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(dr["PressDate"]);
                b.Price = dr["Price"].Equals(DBNull.Value) ? (decimal?)null : Convert.ToInt32(dr["Price"]);
                b.Total = Convert.ToInt32(dr["Total"]);
                b.Remain = Convert.ToInt32(dr["Remain"]);
            }

            dr.Close();

            return b;
        }

        public static int DelBookInfoByID(long iid, SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("exec proc_del_bookinfo {0}", iid);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }


        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.InfoID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO BookInfo");
            sql.AppendFormat("VALUES(@catid,@title,@alpha,@isbn,@aid,@pid,@pdate,@price,default,default)\n");
            sql.AppendLine("SELECT SCOPE_IDENTITY()");

            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

            SqlParameter paramCatID = new SqlParameter("@catid", SqlDbType.Int);
            SqlParameter paramTitle = new SqlParameter("@title", SqlDbType.NVarChar);
            SqlParameter paramAlpha = new SqlParameter("@alpha", SqlDbType.Char);
            SqlParameter paramISBN = new SqlParameter("@isbn", SqlDbType.Char);
            SqlParameter paramAuthorID = new SqlParameter("@aid", SqlDbType.Int);
            SqlParameter paramPressID = new SqlParameter("@pid", SqlDbType.Int);
            SqlParameter paramPressDate = new SqlParameter("@pdate", SqlDbType.DateTime);
            SqlParameter paramPrice = new SqlParameter("@price", SqlDbType.Money);

            paramCatID.Value = CatID ?? (object)DBNull.Value;
            paramTitle.Value = Title ?? (object)"无题";
            paramAlpha.Value = Alphabet;
            paramISBN.Value = ISBN ?? (object)DBNull.Value;
            paramAuthorID.Value = AuthorID ?? (object)DBNull.Value;
            paramPressID.Value = PressID ?? (object)DBNull.Value;
            paramPressDate.Value = PressDate ?? (object)DBNull.Value;
            paramPrice.Value = Price ?? (object)DBNull.Value;

            cmd.Parameters.Add(paramCatID);
            cmd.Parameters.Add(paramTitle);
            cmd.Parameters.Add(paramAlpha);
            cmd.Parameters.Add(paramISBN);
            cmd.Parameters.Add(paramAuthorID);
            cmd.Parameters.Add(paramPressID);
            cmd.Parameters.Add(paramPressDate);
            cmd.Parameters.Add(paramPrice);

            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                InfoID = Convert.ToInt64(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("exec proc_del_bookinfo {0}", InfoID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE BookInfo");
            sql.AppendLine("SET CatID=@catid,Title=@title,Alphabet=@alpha,ISBN=@isbn,AuthorID=@aid,PressID=@pid,PressDate=@pdate,Price=@price,Total=@total,Remain=@remain");
            sql.AppendFormat("WHERE InfoID={0}\n", InfoID);

            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);


            SqlParameter paramCatID = new SqlParameter("@catid", SqlDbType.Int);
            SqlParameter paramTitle = new SqlParameter("@title", SqlDbType.NVarChar);
            SqlParameter paramAlpha = new SqlParameter("@alpha", SqlDbType.Char);
            SqlParameter paramISBN = new SqlParameter("@isbn", SqlDbType.Char);
            SqlParameter paramAuthorID = new SqlParameter("@aid", SqlDbType.Int);
            SqlParameter paramPressID = new SqlParameter("@pid", SqlDbType.Int);
            SqlParameter paramPressDate = new SqlParameter("@pdate", SqlDbType.DateTime);
            SqlParameter paramPrice = new SqlParameter("@price", SqlDbType.Money);
            SqlParameter paramTotal = new SqlParameter("@total", SqlDbType.Int);
            SqlParameter paramRemain = new SqlParameter("@remain", SqlDbType.Int);

            paramCatID.Value = CatID ?? (object)DBNull.Value;
            paramTitle.Value = Title ?? (object)"无题";
            paramAlpha.Value = Alphabet;
            paramISBN.Value = ISBN ?? (object)DBNull.Value;
            paramAuthorID.Value = AuthorID ?? (object)DBNull.Value;
            paramPressID.Value = PressID ?? (object)DBNull.Value;
            paramPressDate.Value = PressDate ?? (object)DBNull.Value;
            paramPrice.Value = Price ?? (object)DBNull.Value;
            paramTotal.Value = Total;
            paramRemain.Value = Remain;

            cmd.Parameters.Add(paramCatID);
            cmd.Parameters.Add(paramTitle);
            cmd.Parameters.Add(paramAlpha);
            cmd.Parameters.Add(paramISBN);
            cmd.Parameters.Add(paramAuthorID);
            cmd.Parameters.Add(paramPressID);
            cmd.Parameters.Add(paramPressDate);
            cmd.Parameters.Add(paramPrice);
            cmd.Parameters.Add(paramTotal);
            cmd.Parameters.Add(paramRemain);


            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
