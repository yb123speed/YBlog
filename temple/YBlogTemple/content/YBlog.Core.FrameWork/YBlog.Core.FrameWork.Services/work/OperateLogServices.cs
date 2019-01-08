
	//----------OperateLog开始----------
    

using System;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
using YBlog.Core.FrameWork.Entity;

namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// OperateLogServices
	/// </summary>	
	public class OperateLogServices : BaseServices<OperateLog>, IOperateLogServices
    {
	
        IOperateLogRepository dal;
        public OperateLogServices(IOperateLogRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------OperateLog结束----------
	