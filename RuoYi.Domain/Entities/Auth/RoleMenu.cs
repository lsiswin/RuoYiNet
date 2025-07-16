using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.System;

namespace RuoYi.Domain.Entities.Auth
{
    /// <summary>
    /// 角色菜单关联实体
    /// </summary>
    public class RoleMenu
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; private set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public long MenuId { get; private set; }

        /// <summary>
        /// 角色导航属性
        /// </summary>
        public Role Role { get; private set; }

        /// <summary>
        /// 菜单导航属性
        /// </summary>
        public Menu Menu { get; private set; }

        // 私有构造函数，防止直接实例化
        private RoleMenu() { }

        /// <summary>
        /// 创建角色菜单关联的工厂方法
        /// </summary>
        public static RoleMenu Create(long roleId, long menuId)
        {
            if (roleId <= 0)
                throw new ArgumentException("角色ID无效", nameof(roleId));

            if (menuId <= 0)
                throw new ArgumentException("菜单ID无效", nameof(menuId));

            return new RoleMenu
            {
                RoleId = roleId,
                MenuId = menuId
            };
        }

        /// <summary>
        /// 设置角色
        /// </summary>
        public void SetRole(Role role)
        {
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        public void SetMenu(Menu menu)
        {
            Menu = menu ?? throw new ArgumentNullException(nameof(menu));
        }
    }
}
