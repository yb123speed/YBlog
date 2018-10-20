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

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="advertisementServices"></param>
        public BlogController(IAdvertisementServices advertisementServices)
        {
            _advertisementServices = advertisementServices;
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
        /// 根据id查询Advertisement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<Advertisement> Get(int id)
        {
            //IAdvertisementServices advertisementServices = new AdvertisementServices();
            return await _advertisementServices.QueryByID(id);
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
    }
}
