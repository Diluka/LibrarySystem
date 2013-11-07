using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace LibraryManagement
{
    class DBHelper
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public static FrmBookManager fbm = null;
        public static FrmLeaseManager flm = null;
        public static FrmUserManager fum = null;
        public static BookReturnForm brf = null;
        public static Form1 f1 = null;
        public static frmRent frt = null;
    }
}
