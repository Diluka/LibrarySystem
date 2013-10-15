using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryDB
{
    class DBHelper
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");
    }
}
