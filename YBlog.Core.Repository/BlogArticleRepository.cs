using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YBlog.Core.IRepository;
using YBlog.Core.Models.Models;
using YBlog.Core.Repository.Base;

namespace YBlog.Core.Repository
{
    public class BlogArticleRepository : BaseRepository<BlogArticle>, IBlogArticleRepository
    {
        
    }
}
