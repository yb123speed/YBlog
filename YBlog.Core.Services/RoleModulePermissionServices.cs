using System;
using YBlog.Core.IServices;
using YBlog.Core.IRepository;
using YBlog.Core.Models.Models;
using YBlog.Core.Services.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YBlog.Core.Services
{
    /// <summary>
    /// RoleModulePermissionServices
    /// </summary>	
    public class RoleModulePermissionServices : BaseServices<RoleModulePermission>, IRoleModulePermissionServices
    {

        IRoleModulePermissionRepository dal;

        IModuleRepository moduleRepository;

        IRoleRepository roleRepository;

        // 将多个仓储接口注入
        public RoleModulePermissionServices(
            IRoleModulePermissionRepository dal,
            IModuleRepository moduleRepository,
            IRoleRepository roleRepository
            )
        {
            this.dal = dal;
            this.moduleRepository = moduleRepository;
            this.roleRepository = roleRepository;
            base.baseDal = dal;
        }

        /// <summary>
        /// 获取全部 角色接口(按钮)关系数据 注意我使用咱们之前的AOP缓存，很好的应用上了
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<RoleModulePermission>> GetRoleModule()
        {
            var roleModulePermissions = await dal.Query(a=>a.IsDeleted == false);
            if (roleModulePermissions.Count > 0)
            {
                foreach (var item in roleModulePermissions)
                {
                    item.Role = await roleRepository.QueryByID(item.RoleId);
                    item.Module = await moduleRepository.QueryByID(item.ModuleId);
                }
            }

            return roleModulePermissions;
        }

    }
}
