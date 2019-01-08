
	//----------RoleModulePermission开始----------
    

using System;
using YBlog.Core.Models.Models;using YBlog.Core.IServices.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YBlog.Core.IServices
{	
	/// <summary>
	/// RoleModulePermissionServices
	/// </summary>	
    public interface IRoleModulePermissionServices :IBaseServices<RoleModulePermission>
	{
        Task<List<RoleModulePermission>> GetRoleModule();
    }
}

	//----------RoleModulePermission结束----------
	