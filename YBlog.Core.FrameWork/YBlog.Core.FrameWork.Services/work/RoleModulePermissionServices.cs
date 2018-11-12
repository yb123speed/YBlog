
	//----------RoleModulePermission开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// RoleModulePermissionServices
	/// </summary>	
	public class RoleModulePermissionServices : BaseServices<RoleModulePermission>, IRoleModulePermissionServices
    {
	
        IRoleModulePermissionRepository dal;
        public RoleModulePermissionServices(IRoleModulePermissionRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------RoleModulePermission结束----------
	