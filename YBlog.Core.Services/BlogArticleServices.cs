using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YBlog.Core.IRepository;
using YBlog.Core.IServices;
using YBlog.Core.Models.Models;
using YBlog.Core.Services.Base;

namespace YBlog.Core.Services
{
    public class BlogArticleServices : BaseServices<BlogArticle>, IBlogArticleServices
    {
        #region private fields and constructor

        IBlogArticleRepository _blogArticleRepository;

        public BlogArticleServices(IBlogArticleRepository blogArticleRepository)
        {
            _blogArticleRepository = blogArticleRepository;
        }

        #endregion

        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BlogArticle>> GetBlogs()
        {
            var blogList = await _blogArticleRepository.Query(a => a.BId > 0, a => a.BId);
            return blogList;
        }
    }
}
