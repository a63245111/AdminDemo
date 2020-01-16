using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DataAccess.Dapper
{
    public interface IDapperHelper
    {
        Database GetConnection();
        T Get<T>(long id, DbTransaction tran = null, int? commandTimeout = null) where T : class;
        IEnumerable<T> GetAll<T>(object predicate = null, IList<ISort> sort = null, DbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class;
        IEnumerable<T> GetPage<T>(object predicate, IList<ISort> sort, int page, int pagesize, DbTransaction tran = null, int? commandTimeout = null, bool buffered = true) where T : class;
        dynamic Insert<T>(T obj, DbTransaction tran = null, int? commandTimeout = null) where T : class;
        void Insert<T>(IEnumerable<T> list, DbTransaction tran = null, int? commandTimeout = null) where T : class;
        bool Update<T>(T obj, DbTransaction tran = null, int? commandTimeout = null) where T : class;
        bool Update<T>(IEnumerable<T> list, DbTransaction tran = null, int? commandTimeout = null) where T : class;
        bool Delete<T>(T obj, DbTransaction tran = null, int? commandTimeout = null) where T : class;
        bool Delete<T>(IEnumerable<T> list, DbTransaction tran = null, int? commandTimeout = null) where T : class;
        IDbTransaction TranStart();
        void TranRollBack(IDbTransaction tran);
        void TranCommit(IDbTransaction tran);
        List<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        int Execute<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}
