
	//----------Role开始----------
    
using System;
namespace YBlog.Core.FrameWork.Entity
{	
	/// <summary>
	/// Role
	/// </summary>	
	public class Role//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  Id { get; set; }


	  public bool  ? IsDeleted { get; set; }


	  public string  Name { get; set; }


	  public string  Description { get; set; }


	  public int  OrderSort { get; set; }


	  public bool  Enabled { get; set; }


	  public int  ? CreateId { get; set; }


	  public string  CreateBy { get; set; }


	  public DateTime  ? CreateTime { get; set; }


	  public int  ? ModifyId { get; set; }


	  public string  ModifyBy { get; set; }


	  public DateTime  ? ModifyTime { get; set; }
 

    }
}

	//----------Role结束----------
	