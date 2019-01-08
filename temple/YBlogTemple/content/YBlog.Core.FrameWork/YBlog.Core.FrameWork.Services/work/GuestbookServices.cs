
	//----------Guestbook开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// GuestbookServices
	/// </summary>	
	public class GuestbookServices : BaseServices<Guestbook>, IGuestbookServices
    {
	
        IGuestbookRepository dal;
        public GuestbookServices(IGuestbookRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Guestbook结束----------
	