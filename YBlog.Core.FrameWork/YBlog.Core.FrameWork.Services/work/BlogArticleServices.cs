
	//----------BlogArticle开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// BlogArticleServices
	/// </summary>	
	public class BlogArticleServices : BaseServices<BlogArticle>, IBlogArticleServices
    {
	
        IBlogArticleRepository dal;
        public BlogArticleServices(IBlogArticleRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------BlogArticle结束----------
	