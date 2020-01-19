using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Dapper.Internal
{
    /// <summary>
    /// 实体接口
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
