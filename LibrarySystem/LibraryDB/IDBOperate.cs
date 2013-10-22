using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    /// <summary>
    /// 实体类数据库操作接口
    /// </summary>
    public interface IDBOperate
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="conn">连接</param>
        /// <returns></returns>
        int Insert(SqlConnection conn);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="conn">连接</param>
        /// <returns></returns>
        int Delete(SqlConnection conn);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="conn">连接</param>
        /// <returns></returns>
        int Update(SqlConnection conn);
    }
}
