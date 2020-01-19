using DataAccess.Dapper;
using Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : RepositoryBase<WebUser>, IUserService
    {
        private static readonly string TableName = "WebUser";
        public async Task<WebUser> DetailAsync(int Id)
        {
            return await DetailAsync(Id, TableName);
        }
    }
}
