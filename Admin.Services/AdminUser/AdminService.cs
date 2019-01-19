using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Admin.Data.User;

namespace Admin.Services.AdminUser
{
    public class AdminService : IAdminService
    {
        public Data.User.AdminUser Detail(int id)
        {
            var data = new Data.User.AdminUser() { Id = 1, Name = "测试", PassWord = "123456", RoleId = 1 };
            return data;
        }
    }
}
