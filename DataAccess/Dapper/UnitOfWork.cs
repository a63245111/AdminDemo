using DataAccess.Dapper.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction _transaction;
        private readonly Action<UnitOfWork> _onCommit;
        private readonly Action<UnitOfWork> _onRollback;
        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="onCommitOrRollback"></param>
        public UnitOfWork(IDbTransaction transaction, Action<UnitOfWork> onCommitOrRollback) : this(transaction, onCommitOrRollback, onCommitOrRollback)
        {
        }
        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="onCommit"></param>
        /// <param name="onRollback"></param>
        public UnitOfWork(IDbTransaction transaction, Action<UnitOfWork> onCommit, Action<UnitOfWork> onRollback)
        {
            _transaction = transaction;
            _onCommit = onCommit;
            _onRollback = onRollback;
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }
        /// <summary>
        /// 保存
        /// </summary>
        public void SaveChanges()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("该工作单元已经保存或撤消。");
            }              
            try
            {
                _transaction.Commit();
                _onCommit(this);
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
        /// <summary>
        /// 注销
        /// </summary>
        public void Dispose()
        {
            if (_transaction == null) return;

            try
            {
                _transaction.Rollback();
                _onRollback(this);
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }


    }
}
