
	//----------Guestbook开始----------
    

using System;
using YBlog.Core.IServices;
using YBlog.Core.IRepository;
using YBlog.Core.Models.Models;
using YBlog.Core.Services.Base;

namespace YBlog.Core.Services
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
	