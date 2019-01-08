using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YBlog.Core.AuthHelper;

namespace YBlog.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("LimitRequests")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 获取JWT的方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public object GetJWTStr(string name = "admins", string pass = "admins")
        {
            //这里就是用户登陆以后，通过数据库去调取数据，分配权限的操作
            string jwtStr = string.Empty;
            bool suc = false;
            //这里就是用户登陆以后，通过数据库去调取数据，分配权限的操作
            //这里直接写死了
            if (name == "admins" && pass == "admins")
            {
                TokenModelJWT tokenModel = new TokenModelJWT();
                tokenModel.Uid = 1;
                tokenModel.Role = "Admin";

                jwtStr = JwtHelper.IssueJWT(tokenModel);
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }
            var result = new
            {
                data = new { success = suc, token = jwtStr }
            };


            return result;
        }
    }
}