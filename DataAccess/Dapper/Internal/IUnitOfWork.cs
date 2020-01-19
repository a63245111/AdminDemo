using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Dapper.Internal
{
    /// <summary>
    /// 工作单元接口，用于数据库事务
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 事务保存
        /// </summary>
        void SaveChanges();
        IDbTransaction Transaction { get; }
    }
}
