
	//----------sysUserInfo开始----------
    
using System;
namespace YBlog.Core.FrameWork.Entity
{	
	/// <summary>
	/// sysUserInfo
	/// </summary>	
	public class sysUserInfo//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  uID { get; set; }


	  public string  uLoginName { get; set; }


	  public string  uLoginPWD { get; set; }


	  public string  uRealName { get; set; }


	  public int  uStatus { get; set; }


	  public string  uRemark { get; set; }


	  public DateTime  uCreateTime { get; set; }


	  public DateTime  uUpdateTime { get; set; }


	  public DateTime  uLastErrTime { get; set; }


	  public int  uErrorCount { get; set; }
 

    }
}

	//----------sysUserInfo结束----------
	