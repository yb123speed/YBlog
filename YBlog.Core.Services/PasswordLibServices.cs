
	//----------PasswordLib开始----------
    

using System;
using YBlog.Core.IServices;
using YBlog.Core.IRepository;
using YBlog.Core.Models.Models;
using YBlog.Core.Services.Base;

namespace YBlog.Core.Services
{	
	/// <summary>
	/// PasswordLibServices
	/// </summary>	
	public class PasswordLibServices : BaseServices<PasswordLib>, IPasswordLibServices
    {
	
        IPasswordLibRepository dal;
        public PasswordLibServices(IPasswordLibRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------PasswordLib结束----------
	