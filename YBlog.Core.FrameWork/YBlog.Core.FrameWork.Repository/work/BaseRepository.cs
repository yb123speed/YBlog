
    
	//----------开始----------
	
using System;
using YBlog.Core.FrameWork.Entity;
using YBlog.Core.FrameWork.IRepository;
namespace YBlog.Core.FrameWork.Repository
{	
	/// <summary>
	/// IBaseRepository
	/// </summary>	
	 public  class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {

       
    }
}

	//----------结束----------
	