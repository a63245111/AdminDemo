using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    /// <summary>
    /// api 基类
    /// </summary>
    //[AllowAnonymous]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        #region api返回结果封装
        /// <summary>
        /// 错误返回
        /// </summary>
        /// <param name="msg">错误消息</param>
        /// <param name="errorCode">错误码</param>
        /// <returns></returns>
        protected virtual JsonResult ToFailResult(string msg, int errorCode = 100)
        {
            var result = new ApiResultModel()
            {
                ErrorCode = errorCode,
                Msg = msg
            };
            return Json(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        protected virtual JsonResult ToResult(string msg, int errorCode)
        {
            var result = new ApiResultModel()
            {
                ErrorCode = errorCode,
                Msg = msg
            };
            return Json(result);
        }

        /// <summary>
        /// 成功返回结果.body为空
        /// </summary>
        /// <param name="msg">成功提示消息</param>
        /// <returns></returns>
        protected virtual JsonResult ToSuccessResult(string msg = "")
        {
            var result = new ApiResultModel()
            {
                ErrorCode = 0,
                Msg = msg
            };
            return Json(result);
        }

        /// <summary>
        /// 成功返回结果.带body数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual JsonResult ToSuccessResult<T>(T body, string msg = "")
        {
            var result = new ApiResultModel<T>()
            {
                Body = body,
                ErrorCode = 0,
                Msg = msg
            };
            return Json(result);
        }
        #endregion
    }
}