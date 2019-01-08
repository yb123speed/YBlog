
	//----------ModulePermission开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// ModulePermissionServices
	/// </summary>	
	public class ModulePermissionServices : BaseServices<ModulePermission>, IModulePermissionServices
    {
	
        IModulePermissionRepository dal;
        public ModulePermissionServices(IModulePermissionRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------ModulePermission结束----------
	