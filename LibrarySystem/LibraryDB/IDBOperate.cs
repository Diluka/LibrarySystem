using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    interface IDBOperate
    {
        int Insert(SqlConnection conn);
        int Delete(SqlConnection conn);
        int Update(SqlConnection conn);
    }
}
