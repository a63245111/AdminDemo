using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dapper.Internal
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// 新增-异步
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<int> InsertAsync(T entity, string sql);
        /// <summary>
        /// 新增-同步
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        int Insert(T entity, string sql);
        /// <summary>
        /// 编辑-异步
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(T entity, string sql);
        /// <summary>
        /// 编辑-同步
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        int Update(T entity, string sql);
        /// <summary>
        /// 删除-同步
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        int Delete(int Id, string TableName);
        /// <summary>
        /// 删除-同步
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(int Id, string TableName);
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<List<T>> GetListAsync(string sql);
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="TableName">表名</param>
        /// <param name="Fileds">字段</param>
        /// <returns></returns>
        Task<T> DetailAsync(int Id, string TableName, string Fileds = null);
    }
}
