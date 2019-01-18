using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Data.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    /// <summary>
    /// 系统权限
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        //[Authorize(Policy = "Admin")]
        public ActionResult<AdminUser> Get(int id)
        {
            return new AdminUser() { Id = 1,Name = "测试", PassWord = "123456", RoleId = 1};
        }


    }
}
