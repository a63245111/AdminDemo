using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Dapper
{
    /// <summary>
    /// Dapper Sql查询对象
    /// </summary>
    public class SqlQuery
    {
        /// <summary>
        /// 获取单值
        /// </summary>
        public override async Task<object> ToScalarAsync(IDbConnection connection = null)
        {
            return await QueryAsync(async (con, sql, sqlParmas) => await con.ExecuteScalarAsync(sql, sqlParmas), connection);
        }

    }
}
