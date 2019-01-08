
	//----------Role开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
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
	