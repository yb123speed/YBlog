
	//----------sysUserInfo开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// sysUserInfoServices
	/// </summary>	
	public class sysUserInfoServices : BaseServices<sysUserInfo>, IsysUserInfoServices
    {
	
        IsysUserInfoRepository dal;
        public sysUserInfoServices(IsysUserInfoRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------sysUserInfo结束----------
	