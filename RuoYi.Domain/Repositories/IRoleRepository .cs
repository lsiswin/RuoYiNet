using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.Auth;
using RuoYi.Domain.Entities.System;

namespace RuoYi.Domain.Repositories
{
    /// <summary>
    /// 角色仓储接口
    /// </summary>
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// 根据角色名获取角色
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <returns>角色</returns>
        Task<Role> GetByNameAsync(string roleName);

        /// <summary>
        /// 根据规范化角色名获取角色
        /// </summary>
        /// <param name="normalizedRoleName">规范化角色名</param>
        /// <returns>角色</returns>
        Task<Role> GetByNormalizedNameAsync(string normalizedRoleName);

        /// <summary>
        /// 根据角色编码获取角色
        /// </summary>
        /// <param name="code">角色编码</param>
        /// <returns>角色</returns>
        Task<Role> GetByCodeAsync(string code);

        /// <summary>
        /// 获取角色的菜单
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>菜单集合</returns>
        Task<IEnumerable<Menu>> GetRoleMenusAsync(long roleId);

        /// <summary>
        /// 获取角色的部门
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>部门集合</returns>
        Task<IEnumerable<Dept>> GetRoleDeptsAsync(long roleId);

        /// <summary>
        /// 获取角色的用户
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>用户集合</returns>
        Task<IEnumerable<User>> GetRoleUsersAsync(long roleId);
    }
}
