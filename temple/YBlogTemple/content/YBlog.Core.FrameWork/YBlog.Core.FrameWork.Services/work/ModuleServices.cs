
	//----------Module开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// ModuleServices
	/// </summary>	
	public class ModuleServices : BaseServices<Module>, IModuleServices
    {
	
        IModuleRepository dal;
        public ModuleServices(IModuleRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Module结束----------
	