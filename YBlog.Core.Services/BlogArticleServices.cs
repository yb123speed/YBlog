using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBlog.Core.IRepository;
using YBlog.Core.IServices;
using YBlog.Core.Models.Models;
using YBlog.Core.Models.ViewModels;
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

        public async Task<BlogViewModel> GetBlogDetails(int id)
        {
            var bloglist = await _blogArticleRepository.Query(a => a.BId > 0, a => a.BId);
            var idmin = bloglist.FirstOrDefault() != null ? bloglist.FirstOrDefault().BId : 0;
            var idmax = bloglist.LastOrDefault() != null ? bloglist.LastOrDefault().BId : 1;
            var idminshow = id;
            var idmaxshow = id;

            BlogArticle blogArticle = new BlogArticle();

            blogArticle = (await _blogArticleRepository.Query(a => a.BId == idminshow)).FirstOrDefault();

            BlogArticle prevblog = new BlogArticle();


            while (idminshow > idmin)
            {
                idminshow--;
                prevblog = (await _blogArticleRepository.Query(a => a.BId == idminshow)).FirstOrDefault();
                if (prevblog != null)
                {
                    break;
                }
            }

            BlogArticle nextblog = new BlogArticle();
            while (idmaxshow < idmax)
            {
                idmaxshow++;
                nextblog = (await _blogArticleRepository.Query(a => a.BId == idmaxshow)).FirstOrDefault();
                if (nextblog != null)
                {
                    break;
                }
            }


            blogArticle.BTraffic += 1;
            await _blogArticleRepository.Update(blogArticle, new List<string> { "BTraffic" });

            BlogViewModel models = new BlogViewModel()
            {
                BSubmitter = blogArticle.BSubmitter,
                BTitle = blogArticle.BTitle,
                BCategory = blogArticle.BCategory,
                BContent = blogArticle.BContent,
                BTraffic = blogArticle.BTraffic,
                BCommentNum = blogArticle.BCommentNum,
                BUpdateTime = blogArticle.BUpdateTime,
                BCreateTime = blogArticle.BCreateTime,
                BRemark = blogArticle.BRemark,
            };

            if (nextblog != null)
            {
                models.Next = nextblog.BTitle;
                models.NextId = nextblog.BId;
            }

            if (prevblog != null)
            {
                models.Previous = prevblog.BTitle;
                models.PreviousId = prevblog.BId;
            }
            return models;
        }

    }
}
