
	//----------TopicDetail开始----------
    

using System;
using YBlog.Core.IServices;
using YBlog.Core.IRepository;
using YBlog.Core.Models.Models;
using YBlog.Core.Services.Base;

namespace YBlog.Core.Services
{	
	/// <summary>
	/// TopicDetailServices
	/// </summary>	
	public class TopicDetailServices : BaseServices<TopicDetail>, ITopicDetailServices
    {
	
        ITopicDetailRepository dal;
        public TopicDetailServices(ITopicDetailRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------TopicDetail结束----------
	