using System;
using SqlSugar;

namespace YBlog.Core.Models.Models
{
    /// <summary>
    /// RoleModulePermission 接口、角色关联表（以后可以把按钮设计进来）
    /// </summary>	
    public class RoleModulePermission//可以在这里加上基类等
    {
        public int Id { get; set; }

        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单ID，这里就是api地址的信息
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// 按钮ID
        /// </summary>
        public int? PermissionId { get; set; }

        public int? CreateId { get; set; }

        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        public int? ModifyId { get; set; }

        public string ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }


        // 请注意，下边三个实体参数，只是做传参作用，所以忽略下，不然会认为缺少字段
        [SugarColumn(IsIgnore = true)]
        public virtual Role Role { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual Module Module { get; set; }
        [SugarColumn(IsIgnore = true)]
        public virtual Permission Permission { get; set; }
    }
}
