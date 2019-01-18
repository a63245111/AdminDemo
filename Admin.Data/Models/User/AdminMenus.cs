using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Data.User
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class AdminMenus
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 菜单名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

    }
}
