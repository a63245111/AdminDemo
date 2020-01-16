using DataAccess.Dapper;
using Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class UserService : IUserService
    {
        public DapperHelper _dapperHelper;
        public UserService(DapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public WebUser Deatail(long Id)
        {
            return _dapperHelper.Get<WebUser>(Id);
        }
    }
}
