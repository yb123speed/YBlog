
	//----------UserRole开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
	public class UserRoleServices : BaseServices<UserRole>, IUserRoleServices
    {
	
        IUserRoleRepository dal;
        public UserRoleServices(IUserRoleRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------UserRole结束----------
	