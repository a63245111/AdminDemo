using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Dapper.Internal
{
    /// <summary>
    /// 数据库连接上下文接口
    /// </summary>
    public interface IContext : IDisposable
    {
        bool IsTransactionStarted { get; }

        IDbConnection Connection { get; }

        IDbTransaction ActiveTransaction { get; }


        UnitOfWork CreateUnitOfWork(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
