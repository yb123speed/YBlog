
	//----------TopicDetail开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
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
	