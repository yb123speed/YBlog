using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YBlog.Core.IServices.Base;
using YBlog.Core.Models.Models;
using YBlog.Core.Models.ViewModels;

namespace YBlog.Core.IServices
{
    public interface IBlogArticleServices:IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
        Task<BlogViewModel> GetBlogDetails(int id);
    }
}
