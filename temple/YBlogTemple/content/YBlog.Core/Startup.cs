﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using YBlog.Core.AOP;
using YBlog.Core.AuthHelper;
using YBlog.Core.Filters;
using YBlog.Core.IServices;
using YBlog.Core.Log;
using YBlog.Core.Repository;
using YBlog.Core.Services;
using static YBlog.Core.SwaggerHelper.CustomApiVersion;

namespace YBlog.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region Log4Net

            repository = LogManager.CreateRepository(Assembly.GetExecutingAssembly().GetName().Name); //需要获取日志的仓库名，也就是你的当然项目名
            //指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config")); //配置文件
            #endregion
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository repository { get; set; }

        private const string ApiName = "YBlog.Core";

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o=>
            {
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region 依赖注入

            services.AddScoped<ICaching, MemoryCaching>();
            services.AddScoped<IRedisCacheManager, RedisCacheManager>();
            services.AddSingleton<ILoggerHelper, LogHelper>();
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

            // 依赖注入，将自定义的授权处理器 匹配给官方授权处理器接口，这样当系统处理授权的时候，就会直接访问我们自定义的授权处理器了。
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            #endregion

            #region AutoMapper

            services.AddAutoMapper(typeof(Startup));

            #endregion

            //数据库配置
            BaseDBConfig.ConnectionString = Configuration.GetSection("AppSettings:SqlServer:SqlServerConnection").Value;

            #region CORS

            services.AddCors(o => {
                o.AddPolicy("AllRequests",policy=> 
                {
                    policy
                    .AllowAnyOrigin() //允许同源
                    .AllowAnyMethod() //允许任何方式
                    .AllowAnyHeader()  //允许任何头
                    .AllowCredentials(); //允许cookie
                });
                //↑↑↑↑↑↑↑注意正式环境不要使用这种全开放的处理↑↑↑↑↑↑↑↑↑↑

                //一般采用这种方法
                o.AddPolicy("LimitRequests", policy=> {
                    policy
                    .WithOrigins("http://127.0.0.1:1818", "http://localhost:8080", "http://localhost:8021", "http://localhost:8081", "http://localhost:1818", "http://blog.core.xxx.com", "")//支持多个域名端口
                    .WithMethods("GET", "POST", "PUT", "DELETE")//请求方法添加到策略
                    .WithHeaders("authorization");//标头添加到策略
                });
            });

            #endregion

            #region Swagger
            services.AddSwaggerGen(o =>
            {
                //o.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info {
                //    Version = "v0.1.0",
                //    Title = "YBlog.Core API",
                //    Description = "框架说明文档",
                //    TermsOfService = "None",
                //    Contact = new Swashbuckle.AspNetCore.Swagger.Contact{
                //        Name = "YBlog.Core",
                //        Email = "yb123speed@outlook.com",
                //        Url = "http://www.chaney.club"
                //    }
                //});

                //遍历出全部的版本，做文档信息展示
                typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                {
                    o.SwaggerDoc(version, new Info
                    {
                        // {ApiName} 定义成全局变量，方便修改
                        Version = version,
                        Title = $"{ApiName} 接口文档",
                        Description = $"{ApiName} HTTP API " + version,
                        TermsOfService = "None",
                        Contact = new Contact { Name = "YBlog.Core", Email = "yb123speed@outlook.com", Url = "http://www.chaney.club" }
                    });
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
                    Description = "JWT授权（数据将在请求头中进行传输）直接在下框输入`Bearer {token}`",
                    Name = "Authorization", //jwt默认的参数名称
                    In = "header", //jwt默认存放Authorization信息的位置（请求头中）
                    Type = "apiKey"
                });
                #endregion
            });
            #endregion

            //#region JwtBearer认证
            //services.AddAuthentication(o=> 
            //{
            //    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(o => 
            //{
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        //ValidIssuer = "YBlog.Core",
            //        //ValidAudience = "wr",
            //        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtHelper.secretKey)),
            //        //RequireSignedTokens = true,
            //        //// 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
            //        //ValidateAudience = false,
            //        //ValidateIssuer = true,
            //        //ValidateIssuerSigningKey = true,
            //        //// 是否要求Token的Claims中必须包含 Expires
            //        //RequireExpirationTime = true,
            //        //// 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
            //        //ValidateLifetime = true

            //        ValidateIssuer = true,//是否验证Issuer
            //        ValidateAudience = true,//是否验证Audience 
            //        ValidateIssuerSigningKey = true,//是否验证IssuerSigningKey 
            //        ValidIssuer = "YBlog.Core",
            //        ValidAudience = "wr",
            //        ValidateLifetime = true,//是否验证超时  当设置exp和nbf时有效 同时启用ClockSkew 
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtHelper.secretKey)),
            //        //注意这是缓冲过期时间，总的有效时间等于这个时间加上jwt的过期时间，如果不配置，默认是5分钟
            //        ClockSkew = TimeSpan.FromSeconds(30)
            //    };
            //});
            //#endregion

            #region Token服务注册

            //读取配置文件
            var audienceConf = Configuration.GetSection("Audience");
            var symmetricKeyAsBase64 = audienceConf["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            // 令牌验证参数，之前我们都是写在AddJwtBearer里的，这里提出来了
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,//验证发行人的签名密钥
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,//验证发行人
                ValidIssuer = audienceConf["Issuer"],//发行人
                ValidateAudience = true,//验证订阅人
                ValidAudience = audienceConf["Audience"],//订阅人
                ValidateLifetime = true,//验证生命周期
                ClockSkew = TimeSpan.Zero,//这个是定义的过期的缓存时间
                RequireExpirationTime = true,//是否要求过期

            };
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // 注意使用RESTful风格的接口会更好，因为只需要写一个Url即可，比如：/api/values 代表了Get Post Put Delete等多个。
            // 如果想写死，可以直接在这里写。
            //var permission = new List<Permission> {
            //                  new Permission {  Url="/api/values", Role="Admin"},
            //                  new Permission {  Url="/api/values", Role="System"},
            //                  new Permission {  Url="/api/claims", Role="Admin"},
            //              };

            // 如果要数据库动态绑定，这里先留个空，后边处理器里动态赋值
            var permission = new List<Permission>();

            // 角色与接口的权限要求参数
            var permissionRequirement = new PermissionRequirement(
                "/api/denied",// 拒绝授权的跳转地址（目前无用）
                permission,//这里还记得么，就是我们上边说到的角色地址信息凭据实体类 Permission
                ClaimTypes.Role,//基于角色的授权
                audienceConf["Issuer"],//发行人
                audienceConf["Audience"],//订阅人
                signingCredentials,//签名凭据
                expiration: TimeSpan.FromSeconds(60 * 2)//接口的过期时间，注意这里没有了缓冲时间，你也可以自定义，在上边的TokenValidationParameters的 ClockSkew
                );

            services.AddAuthorization(o =>
            {
                o.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                o.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                //这个写法是错误的，这个是并列的关系，不是或的关系
                //options.AddPolicy("AdminOrClient", policy => policy.RequireRole("Admin,Client").Build());
                //这个才是或的关系
                o.AddPolicy("AdminOrClient", policy => policy.RequireRole("Admin","Client"));

                // 自定义基于策略的授权权限
                o.AddPolicy("Permission",
                         policy => policy.Requirements.Add(permissionRequirement));
            })

            .AddAuthentication(x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             })

            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenValidationParameters;
            });

            // 将授权必要类注入生命周期内
            services.AddSingleton(permissionRequirement);
            #endregion

            #region AutoFac

            //实例化 AutoFac容器
            var builder = new ContainerBuilder();

            builder.RegisterType<BlogLogAOP>();//可以直接替换其他拦截器！一定要把拦截器进行注册
            builder.RegisterType<BlogCacheAOP>();

            //注册要通过反射创建的组件
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();

            var assemblyServices = Assembly.Load("YBlog.Core.Services");
            //指定已扫描程序集中的类型注册为提供所有其实现的接口
            //builder.RegisterAssemblyTypes(assemblyServices).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblyServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()    //对目标类型启用接口拦截。拦截器将被确定，通过在类或接口上截取属性, 或添加 InterceptedBy ()
                .InterceptedBy(typeof(BlogLogAOP))
                .InterceptedBy(typeof(BlogCacheAOP));    //允许将拦截器服务的列表分配给注册。说人话就是，将拦截器加上要注入容器的的接口或者类上

            //备用方法
            //var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;//获取项目路径
            //var servicesDllFile = Path.Combine(basePath, "Blog.Core.Services.dll");//获取注入项目绝对路径
            //var assemblysServices = Assembly.LoadFile(servicesDllFile);//直接采用加载文件的方法

            var assemblyRepository = Assembly.Load("YBlog.Core.Repository");
            builder.RegisterAssemblyTypes(assemblyRepository).AsImplementedInterfaces();

            //将services 填充AutoFac容器生成器
            builder.Populate(services);

            //使用已进行的组件登记创建容器
            var ApplicationContainer = builder.Build();

            #endregion

            return new AutofacServiceProvider(ApplicationContainer); //第三方IOC接管
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                //之前是写死的
                //o.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                //o.RoutePrefix = "";//路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件

                //根据版本名称倒序 遍历展示
                typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(v =>
                {
                    o.SwaggerEndpoint($"/swagger/{v}/swagger.json", $"{ApiName} {v}");
                });
            });
            #endregion

            //app.UseHttpsRedirection();
            //app.UseJwtTokenAuthMiddleware();
            app.UseAuthentication();

            app.UseCors("LimitRequests"); //将 CORS 中间件添加到 web 应用程序管线中, 以允许跨域请求。有的不加也是可以的，最好是加上吧

            app.UseMvc();
        }
    }
}
