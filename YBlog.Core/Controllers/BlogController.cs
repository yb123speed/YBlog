using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YBlog.Core.IServices;
using YBlog.Core.Models.Models;
using YBlog.Core.Services;

namespace YBlog.Core.Controllers
{
    /// <summary>
    /// 博客
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Admin")]
    public class BlogController : ControllerBase
    {
        #region private fields and constructor

        IAdvertisementServices _advertisementServices;
        IBlogArticleServices _blogArticleServices;
        IRedisCacheManager _redisCacheManager; //缓存

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="advertisementServices"></param>
        /// <param name="blogArticleServices"></param>
        /// <param name="redisCacheManager"></param>
        public BlogController(IAdvertisementServices advertisementServices,
            IBlogArticleServices blogArticleServices,
            IRedisCacheManager redisCacheManager)
        {
            _advertisementServices = advertisementServices;
            _blogArticleServices = blogArticleServices;
            _redisCacheManager = redisCacheManager;
        }

        #endregion

        // GET: api/Blog
        /// <summary>
        /// 两数相加
        /// </summary>
        /// <param name="i">参数1</param>
        /// <param name="j">参数2</param>
        /// <returns></returns>
        [HttpGet]
        public int Get(int i, int j)
        {
            //IAdvertisementServices advertisementServices = new AdvertisementServices();
            return 0;//advertisementServices.Sum(i, j);
        }

        // GET: api/Blog/5
        /// <summary>
        /// 根据id查询Blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<object> Get(int id)
        {
            var model = await _blogArticleServices.GetBlogDetails(id);
            return new { success = true, data = model };
        }

        // POST: api/Blog
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBlogs")]
        public async Task<List<BlogArticle>> GetBlogs()
        {
            List<BlogArticle> blogs = new List<BlogArticle>();

            if (_redisCacheManager.Get<object>("Redis.Blog") != null)
            {
                blogs = _redisCacheManager.Get<List<BlogArticle>>("Redis.Blog");
            }
            else
            {
                blogs = await _blogArticleServices.Query(d => d.BId > 5);
                _redisCacheManager.Set("Redis.Blog", blogs, TimeSpan.FromHours(2));//缓存2小时
            }
            return blogs;
        }

        [HttpGet]
        [ApiExplorerSettings(GroupName = "v2")]
        //路径 如果以 / 开头，表示绝对路径，反之相对 controller 的相对路径
        [Route("/api/v2/blog/Blogtest")]
        public object V2_Blogtest()
        {
            return Ok(new { status = 220, data = "我是第二版的博客信息" });
        }
    }
}
