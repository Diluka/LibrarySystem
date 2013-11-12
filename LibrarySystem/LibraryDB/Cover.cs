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
        public long InfoID { get; private set; }
        public Image CoverImage
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
            s.Position = 0;//这里必须指定为开头，默认居然是结尾
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
        public Cover(long iid, Stream s)
        {
            mem = FromStream(s);
            this.InfoID = iid;
        }

        public static Cover GetCoverByID(long id, SqlConnection conn)
        {
            Cover c = null;
            string sql = string.Format("SELECT * FROM Covers WHERE InfoID={0}", id);

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                c = new Cover();
                c.InfoID = Convert.ToInt64(dr["InfoID"]);
                //c.ImageStream = dr.GetStream(1); //only support above 4.5
                c.mem = new MemoryStream((byte[])dr["CoverImage"]);//below 4.5
            }

            dr.Close();

            return c;
        }

        #region IDBOperate 成员

        int IDBOperate.Insert(SqlConnection conn)
        {

            int result = 0;

            string sql = string.Format("INSERT INTO Covers VALUES({0},@cover)", InfoID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlParameter paramCover = new SqlParameter("@cover", SqlDbType.Image);
            byte[] imgbuf = mem.GetBuffer();
            paramCover.Value = imgbuf;
            cmd.Parameters.Add(paramCover);

            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Delete(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("DELETE Covers WHERE InfoID={0}", InfoID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            return result;
        }

        int IDBOperate.Update(SqlConnection conn)
        {
            int result = 0;

            string sql = string.Format("UPDATE Covers SET CoverImage=@cover WHERE InfoID={0}", InfoID);
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
