using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using YBlog.Core.AuthHelper;

namespace YBlog.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Swagger
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info {
                    Version = "v0.1.0",
                    Title = "YBlog.Core API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact{
                        Name = "YBlog.Core",
                        Email = "yb123speed@outlook.com",
                        Url = "http://www.chaney.club"
                    }
                });

                #region 读取xml信息
                //Configure XML File

                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "YBlog.Core.xml");
                o.IncludeXmlComments(xmlPath,true);//默认的第二个参数是false，这个是controller的注释，记得修改

                //Configure Models XML File
                var xmlModelPath = Path.Combine(basePath, "YBlog.Core.Models.xml");//这个就是Model层的xml文件名
                o.IncludeXmlComments(xmlModelPath);
                #endregion

                #region Token绑定到ConfigureServices
                //添加header验证信息
                //o.OperationFilter<SwaggerHeader>();
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "YBlog.Core",new string[] { } }
                };
                o.AddSecurityRequirement(security);
                //方案名称"YBlog.Core"可自定义，上下一致即可
                o.AddSecurityDefinition("YBlog.Core", new ApiKeyScheme
                {
                    Description = "JWT授权（数据将在请求头中进行传输）直接在下框输入{token}",
                    Name = "Authorization", //jwt默认的参数名称
                    In = "header", //jwt默认存放Authorization信息的位置（请求头中）
                    Type = "apiKey"
                });
                #endregion
            });
            #endregion

            #region 认证
            services.AddAuthentication(o=> 
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o => 
            {
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = "YBlog.Core",
                    ValidAudience = "wr",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtHelper.secretKey)),
                    RequireSignedTokens = true,
                    // 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    // 是否要求Token的Claims中必须包含 Expires
                    RequireExpirationTime = true,
                    // 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                    ValidateLifetime = true
                };
            });
            #endregion


            #region Token服务注册
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

            services.AddAuthorization(o =>
            {
                o.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                o.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                o.AddPolicy("AdminOrClient", policy => policy.RequireRole("Admin","Client").Build());
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                #region Swagger
                app.UseSwagger();
                app.UseSwaggerUI(o =>
                {
                    o.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                });
                #endregion
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseJwtTokenAuthMiddleware();

            app.UseMvc();
        }
    }
}
