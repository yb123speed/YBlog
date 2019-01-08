
	//----------Topic开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// TopicServices
	/// </summary>	
	public class TopicServices : BaseServices<Topic>, ITopicServices
    {
	
        ITopicRepository dal;
        public TopicServices(ITopicRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Topic结束----------
	