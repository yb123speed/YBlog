
//----------Module开始----------

using System;
namespace YBlog.Core.Models.Models
{
    /// <summary>
    /// 接口API地址信息表
    /// </summary>	
    public class Module
    {
        public int Id { get; set; }

        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// API链接地址
        /// </summary>
        public string LinkUrl { get; set; }

        public string Area { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Action名称
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderSort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public bool IsMenu { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enabled { get; set; }

        public int? CreateId { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyId { get; set; }

        public string ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}

