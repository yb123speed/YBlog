namespace YBlog.Core.AuthHelper
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class JwtTokenAuthMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtTokenAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                await _next.Invoke(context);

            }
            else
            {
                var tokenHeader = context.Request.Headers["Authorization"].ToString();

                TokenModelJWT tm = JwtHelper.SerializeJWT(tokenHeader);//序列化token，获取授权

                //授权 注意这个可以添加多个角色声明，请注意这是一个 list
                var claimList = new List<Claim>();
                var claim = new Claim(ClaimTypes.Role, tm.Role);
                claimList.Add(claim);
                var identity = new ClaimsIdentity(claimList);
                var principal = new ClaimsPrincipal(identity);
                context.User = principal;

                await _next.Invoke(context);
            }
        }

    }
}

namespace Microsoft.AspNetCore.Builder
{
    using System;
    using YBlog.Core.AuthHelper;

    public static partial class MiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtTokenAuthMiddleware(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            return app.UseMiddleware<JwtTokenAuthMiddleware>();
        }
    }
}
