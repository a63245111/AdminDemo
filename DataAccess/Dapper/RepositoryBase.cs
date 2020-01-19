using Dapper;
using DataAccess.Dapper.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Domain.Entities;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataAccess.Dapper
{
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        private readonly IContext _context;

        public virtual DbConnection Connection
        {
            get { return _context.Connection as DbConnection; }
        }

        public int Delete(int Id, string TableName)
        {
            using (IDbConnection Connection = DataBaseConfig.GetSqlConnection())
            {
                var sql = $"DELETE FROM @Table WHERE Id = @Id";
                return Connection.Execute(sql, new { TableName, Id });
            }
        }

        public async Task<int> DeleteAsync(int Id, string TableName)
        {
            using (IDbConnection Connection = DataBaseConfig.GetSqlConnection())
            {
                var sql = $"DELETE FROM @Table WHERE Id = @Id";
                return await Connection.ExecuteAsync(sql, new { TableName, Id });
            }
        }

        public async Task<T> DetailAsync(int Id, string TableName,string Fileds = null)
        {
            using (IDbConnection Connection = DataBaseConfig.GetSqlConnection())
            {
                string sql;
                if (!string.IsNullOrWhiteSpace(Fileds))
                {
                    sql = $"SELECT {Fileds} FROM {TableName} WHERE Id = @Id";
                }
                else
                {
                    sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
                }
                return await Connection.QueryFirstAsync<T>(sql, new { Id });
            }
        }

        public async Task<List<T>> GetListAsync(string sql)
        {
            using (IDbConnection Connection = DataBaseConfig.GetSqlConnection())
            {
                return await Task.Run(() => Connection.Query<T>(sql).ToList());
            }            
        }

        public int Insert(T entity, string sql)
        {
            using (IDbConnection Connection = DataBaseConfig.GetSqlConnection())
            {
                return Connection.Execute(sql, entity);
            }            
        }

        public async Task<int> InsertAsync(T entity, string sql)
        {
            using (IDbConnection Connection = DataBaseConfig.GetSqlConnection())
            {
                return await Connection.ExecuteAsync(sql, entity);
            }             
        }

        public int Update(T entity, string sql)
        {
            using (IDbConnection Connection = DataBaseConfig.GetSqlConnection())
            {
                return Connection.Execute(sql, entity);
            }             
        }

        public async Task<int> UpdateAsync(T entity, string sql)
        {
            using (IDbConnection Connection = DataBaseConfig.GetSqlConnection())
            {
                return await Connection.ExecuteAsync(sql, entity);
            }             
        }
    }
}
