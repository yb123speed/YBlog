
	//----------BlogArticle开始----------
    
using System;
namespace YBlog.Core.FrameWork.Entity
{	
	/// <summary>
	/// BlogArticle
	/// </summary>	
	public class BlogArticle//可以在这里加上基类等
	{
	//将该表下的字段都遍历出来，可以自定义获取数据描述等信息


	  public int  BId { get; set; }


	  public string  BSubmitter { get; set; }


	  public string  BTitle { get; set; }


	  public string  BCategory { get; set; }


	  public string  BContent { get; set; }


	  public int  BTraffic { get; set; }


	  public int  BCommentNum { get; set; }


	  public DateTime  BUpdateTime { get; set; }


	  public DateTime  BCreateTime { get; set; }


	  public string  BRemark { get; set; }
 

    }
}

	//----------BlogArticle结束----------
	