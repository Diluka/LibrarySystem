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
        public static string Name;
        public static string Age;
        public static string Gender;
        public static string Phone;
        public static string Mail;
        public static string DiZhi;
        public static string ZCTime;
        public static string ZH;
        public static string BH;
    }
}
