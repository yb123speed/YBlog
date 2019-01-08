
	//----------PasswordLib开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// PasswordLibServices
	/// </summary>	
	public class PasswordLibServices : BaseServices<PasswordLib>, IPasswordLibServices
    {
	
        IPasswordLibRepository dal;
        public PasswordLibServices(IPasswordLibRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------PasswordLib结束----------
	