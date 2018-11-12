
	//----------Advertisement开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// AdvertisementServices
	/// </summary>	
	public class AdvertisementServices : BaseServices<Advertisement>, IAdvertisementServices
    {
	
        IAdvertisementRepository dal;
        public AdvertisementServices(IAdvertisementRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Advertisement结束----------
	