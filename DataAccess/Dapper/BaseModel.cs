using DataAccess.Dapper.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Dapper
{
    public class BaseModel : IEntity<int>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
    }
}
