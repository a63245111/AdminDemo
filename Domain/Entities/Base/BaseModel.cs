using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BaseModel : IEntity<int>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
    }
}
