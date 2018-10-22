using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YBlog.Core.IServices.Base;
using YBlog.Core.Models.Models;

namespace YBlog.Core.IServices
{
    public interface IBlogArticleServices:IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
    }
}
