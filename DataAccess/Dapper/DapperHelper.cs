using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Common.Enum;
using Dapper;
using DapperExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace DataAccess.Dapper
{
    /// <summary>
    /// Dapper帮助类
    /// </summary>
    public class DapperHelper : IDapperHelper, IDisposable
    {
        private readonly string ConnectionString = string.Empty;
        private readonly Database Connection = null;
        /// <summary>
        /// 初始化 若不传则默认从appsettings.json读取Connections:DefaultConnect节点
        /// 传入setting:xxx:xxx形式 则会从指定的配置文件中读取内容
        /// 直接传入连接串则
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="jsonConfigFileName"> 配置文件名称</param>
        public DapperHelper(string conn = "", DatabaseType databaseType = DatabaseType.SqlServer)
        {
            var config = new ConfigurationBuilder().Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
            if (string.IsNullOrEmpty(conn))
            {
                conn = config.GetSection("Connections:DefaultConnect").Value;
            }
            else if (conn.StartsWith("setting:"))
            {
                conn = config.GetSection(conn.Substring(8)).Value;
            }
            ConnectionString = conn;
            Connection = ConnectionFactory.CreateConnection(ConnectionString, databaseType);
        }
        /// <summary>
        /// 获取数据库连接数据串
        /// </summary>
        /// <returns></returns>
        public Database GetConnection()
        {
            return Connection;
        }
        /// <summary>
        /// 事务开启
        /// </summary>
        /// <returns></returns>
        public IDbTransaction TranStart()
        {
            if (Connection.Connection.State == ConnectionState.Closed)
                Connection.Connection.Open();
            return Connection.Connection.BeginTransaction();
        }
        /// <summary>
        /// 事务回滚
        /// </summary>
        /// <param name="tran"></param>
        public void TranRollBack(IDbTransaction tran)
        {
            tran.Rollback();
            if (Connection.Connection.State == ConnectionState.Open)
                tran.Connection.Close();
        }
        /// <summary>
        /// 事务提交
        /// </summary>
        /// <param name="tran"></param>
        public void TranCommit(IDbTransaction tran)
        {
            tran.Commit();
            if (Connection.Connection.State == ConnectionState.Open)
                tran.Connection.Close();
        }
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Delete<T>(T obj, DbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Delete(obj, tran, commandTimeout);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Delete<T>(IEnumerable<T> list, DbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Delete(list, tran, commandTimeout);
        }
        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public T Get<T>(string id, DbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Get<T>(id, tran, commandTimeout);
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>(object predicate = null, IList<ISort> sort = null, DbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return Connection.GetList<T>(predicate, sort, tran, commandTimeout, buffered);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPage<T>(object predicate, IList<ISort> sort, int page, int pagesize, DbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class
        {
            return Connection.GetPage<T>(predicate, sort, page, pagesize, tran, commandTimeout, buffered);
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public dynamic Insert<T>(T obj, DbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Insert(obj, tran, commandTimeout);
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        public void Insert<T>(IEnumerable<T> list, DbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            Connection.Insert(list, tran, commandTimeout);
        }
        /// <summary>
        /// 单个编辑
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public bool Update<T>(T obj, DbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Update(obj, tran, commandTimeout);
        }
        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        /// <param name="commandTimeout"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool Update<T>(IEnumerable<T> list, DbTransaction tran = null, int? commandTimeout = null) where T : class
        {
            return Connection.Update(list, tran, commandTimeout);
        }
        /// <summary>
        /// 执行SQL返回List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public List<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType).AsList();
        }
        /// <summary>
        /// 执行SQL返回单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int Execute<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Connection.Execute(sql, param, transaction, commandTimeout, commandType);
        }
    }
}
