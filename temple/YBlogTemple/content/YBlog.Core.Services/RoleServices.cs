
	//----------Role开始----------
    

using System;
using YBlog.Core.IServices;
using YBlog.Core.IRepository;
using YBlog.Core.Models.Models;
using YBlog.Core.Services.Base;

namespace YBlog.Core.Services
{	
	/// <summary>
	/// RoleServices
	/// </summary>	
	public class RoleServices : BaseServices<Role>, IRoleServices
    {
	
        IRoleRepository dal;
        public RoleServices(IRoleRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Role结束----------
	