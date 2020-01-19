using DataAccess.Dapper.Internal;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService : IRepositoryBase<WebUser>
    {
        Task<WebUser> DetailAsync(int Id);

    }
}
