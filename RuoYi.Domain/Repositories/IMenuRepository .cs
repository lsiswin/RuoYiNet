using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.System;

namespace RuoYi.Domain.Repositories
{
    /// <summary>
    /// 菜单仓储接口
    /// </summary>
    public interface IMenuRepository : IRepository<Menu>
    {
        /// <summary>
        /// 获取子菜单
        /// </summary>
        /// <param name="parentId">父菜单ID</param>
        /// <returns>子菜单集合</returns>
        Task<IEnumerable<Menu>> GetChildrenAsync(long parentId);

        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <param name="parentId">父菜单ID，默认为根菜单</param>
        /// <returns>菜单树</returns>
        Task<IEnumerable<Menu>> GetMenuTreeAsync(long? parentId = null);

        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>菜单集合</returns>
        Task<IEnumerable<Menu>> GetUserMenusAsync(long userId);

        /// <summary>
        /// 获取用户权限标识
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>权限标识集合</returns>
        Task<IEnumerable<string>> GetUserPermissionsAsync(long userId);
    }
}
