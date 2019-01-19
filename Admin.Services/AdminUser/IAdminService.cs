using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services.AdminUser
{
    public interface IAdminService
    {
        Data.User.AdminUser Detail(int id);
    }
}
