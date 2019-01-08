
	//----------OperateLog开始----------
    

using System;
using YBlog.Core.IServices;
using YBlog.Core.IRepository;
using YBlog.Core.Models.Models;
using YBlog.Core.Services.Base;

namespace YBlog.Core.Services
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
	