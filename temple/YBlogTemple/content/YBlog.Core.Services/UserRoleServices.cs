
	//----------UserRole开始----------
    

using System;
using YBlog.Core.IServices;
using YBlog.Core.IRepository;
using YBlog.Core.Models.Models;
using YBlog.Core.Services.Base;

namespace YBlog.Core.Services
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
	