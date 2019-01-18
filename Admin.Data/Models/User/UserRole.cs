using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Data.User
{
    /// <summary>
    /// 管理员权限
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 权限类型
        /// </summary>
        public int RoleType { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string Menus { get; set; }
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
