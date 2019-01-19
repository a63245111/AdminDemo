using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Api.AuthHelper;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 获取JWT的token信息
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="sub">角色</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token2")]
        public ActionResult<string> GetJWTStr(long id = 1, string sub = "Admin")
        {
            //这里就是用户登录以后，通过数据库去调取数据，分配权限的操作
            TokenModelJWT tokenModel = new TokenModelJWT
            {
                Uid = id,
                Role = sub
            };

            string jwtStr = JwtHelper.IssueJWT(tokenModel);
            return jwtStr;
        }
    }
}