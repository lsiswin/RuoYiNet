using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.System;

namespace RuoYi.Domain.Entities.Auth
{
    /// <summary>
    /// 角色部门关联实体
    /// </summary>
    public class RoleDept
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; private set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public long DeptId { get; private set; }

        /// <summary>
        /// 角色导航属性
        /// </summary>
        public Role Role { get; private set; }

        /// <summary>
        /// 部门导航属性
        /// </summary>
        public Dept Dept { get; private set; }

        // 私有构造函数，防止直接实例化
        private RoleDept() { }

        /// <summary>
        /// 创建角色部门关联的工厂方法
        /// </summary>
        public static RoleDept Create(long roleId, long deptId)
        {
            if (roleId <= 0)
                throw new ArgumentException("角色ID无效", nameof(roleId));

            if (deptId <= 0)
                throw new ArgumentException("部门ID无效", nameof(deptId));

            return new RoleDept
            {
                RoleId = roleId,
                DeptId = deptId
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
        /// 设置部门
        /// </summary>
        public void SetDept(Dept dept)
        {
            Dept = dept ?? throw new ArgumentNullException(nameof(dept));
        }
    }
}
