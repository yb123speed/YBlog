using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YBlog.Core.SwaggerHelper;
using static YBlog.Core.SwaggerHelper.CustomApiVersion;

namespace YBlog.Core.Controllers.v2
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApbController : ControllerBase
    {
        [HttpGet]
        [CustomRoute(ApiVersions.v2, "apbs")]
        public IEnumerable<string> Get()
        {
            return new string[] { "第二版的 apbs" };
        }
    }
}