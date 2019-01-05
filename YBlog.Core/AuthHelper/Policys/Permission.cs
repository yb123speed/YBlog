using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YBlog.Core.AuthHelper
{
    //用来存放我们用户登录成果后，在httptext中存放的角色信息的，是下边 必要参数类 PermissionRequirement 的一个属性

    /// <summary>
    /// 用户或角色或其他凭据实体
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// 用户或角色或其他凭证名称
        /// </summary>
        public virtual string Role { get; set; }

        /// <summary>
        /// 请求Url
        /// </summary>
        public virtual string Url { get; set; }
    }
}
