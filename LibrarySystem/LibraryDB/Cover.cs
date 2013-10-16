using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;

namespace LibraryDB
{
    public class Cover : IDBOperate
    {
        private MemoryStream mem;
        public long CoverID { get; private set; }
        public Image CoverImg
        {
            get
            {
                return Image.FromStream(mem);
            }
        }
        public Stream ImageStream
        {
            set
            {
                mem = FromStream(value);
            }
        }

        private MemoryStream FromStream(Stream s)
        {
            MemoryStream m = new MemoryStream();
            while (true)
            {
                int read = s.ReadByte();
                if (read == -1) break;
                m.WriteByte((byte)read);
            }
            m.Position = 0;
            return m;
        }

        private Cover() { }
        public Cover(Stream s)
        {
            mem = FromStream(s);
            this.CoverID = 0;
        }

        public static Cover GetCoverByID(long id, SqlConnection conn)
        {
            Cover c = null;
            string sql = string.Format("SELECT * FROM Covers WHERE CoverID={0}", id);

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                c = new Cover();
                c.CoverID = Convert.ToInt64(dr["CoverID"]);
                //c.ImageStream = dr.GetStream(1); //only support above 4.5
                c.mem = new MemoryStream((byte[])dr["Cover"]);//below 4.5
            }

            return c;
        }

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {
            if (this.CoverID != 0)
            {
                throw new Exception("ID不等于零，不能插入");
            }

            int result = 0;

            string sql = string.Format("INSERT INTO Covers VALUES(@cover);SELECT SCOPE_IDENTITY()");
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlParameter paramCover = new SqlParameter("@cover", SqlDbType.Image);
            byte[] imgbuf = mem.GetBuffer();
            paramCover.Value = imgbuf;
            cmd.Parameters.Add(paramCover);

            object obj = cmd.ExecuteScalar();
            if (!obj.Equals(DBNull.Value))
            {
                CoverID = Convert.ToInt64(obj);
                result = 1;
            }

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("DELETE Covers WHERE CoverID={0}", CoverID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE Covers SET Cover=@cover WHERE CoverID={0}", CoverID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlParameter paramCover = new SqlParameter("@cover", SqlDbType.Image);
            byte[] imgbuf = mem.GetBuffer();
            paramCover.Value = imgbuf;
            cmd.Parameters.Add(paramCover);

            result = cmd.ExecuteNonQuery();

            return result;
        }

        #endregion
    }
}
