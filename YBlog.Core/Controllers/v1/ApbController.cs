using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YBlog.Core.SwaggerHelper;
using static YBlog.Core.SwaggerHelper.CustomApiVersion;

namespace YBlog.Core.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApbController : ControllerBase
    {
        [HttpGet]
        [CustomRoute(ApiVersions.v1, "apbs")]
        public IEnumerable<string> Get()
        {
            return new string[] { "第一版的 apbs" };
        }
    }
}