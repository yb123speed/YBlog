
    
	//----------开始----------
	
using System;
using YBlog.Core.FrameWork.Entity;
using YBlog.Core.FrameWork.IServices;
using YBlog.Core.FrameWork.IRepository;
namespace YBlog.Core.FrameWork.Services
{	
	/// <summary>
	/// IBaseRepository
	/// </summary>	
	public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
		public IBaseRepository<TEntity> baseDal;
       
    }
}

	//----------结束----------
	