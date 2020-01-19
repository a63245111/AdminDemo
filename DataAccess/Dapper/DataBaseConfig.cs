using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Dapper
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DataBaseConfig
    {
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="sqlConnectionString"></param>
        /// <returns></returns>
        public static IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            var config = new ConfigurationBuilder().Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true }).Build();
            if (string.IsNullOrEmpty(sqlConnectionString))
            {
                sqlConnectionString = config.GetSection("Connections:DefaultConnect").Value;
            }
            else if (sqlConnectionString.StartsWith("setting:"))
            {
                sqlConnectionString = config.GetSection(sqlConnectionString.Substring(8)).Value;
            }
            IDbConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }

    }
}
