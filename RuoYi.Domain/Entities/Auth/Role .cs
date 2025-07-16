using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Common.Enums;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace RuoYi.Domain.Entities.Auth
{
    /// <summary>
    /// 角色聚合根
    /// </summary>
    public class Role : IdentityRole<long>, IAggregateRoot
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public long? CreatedBy { get; private set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModifiedTime { get; private set; }

        /// <summary>
        /// 最后修改者ID
        /// </summary>
        public long? LastModifiedBy { get; private set; }

        /// <summary>
        /// 是否删除（软删除标记）
        /// </summary>
        public bool IsDeleted { get; private set; } = false;

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletedTime { get; private set; }

        /// <summary>
        /// 删除者ID
        /// </summary>
        public long? DeletedBy { get; private set; }

        /// <summary>
        /// 版本号（用于乐观并发控制）
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// 角色的业务属性
        /// </summary>
        public string Code { get; private set; }
        public int OrderNum { get; private set; }
        public int DataScope { get; private set; }
        public bool MenuCheckStrictly { get; private set; }
        public bool DeptCheckStrictly { get; private set; }
        public int Status { get; private set; }
        public string Remark { get; private set; }

        /// <summary>
        /// 角色菜单关联集合
        /// </summary>
        private readonly List<RoleMenu> _roleMenus = new();
        public IReadOnlyCollection<RoleMenu> RoleMenus => _roleMenus.AsReadOnly();

        /// <summary>
        /// 角色部门关联集合
        /// </summary>
        private readonly List<RoleDept> _roleDepts = new();
        public IReadOnlyCollection<RoleDept> RoleDepts => _roleDepts.AsReadOnly();

        /// <summary>
        /// 构造函数
        /// </summary>
        public Role()
        {
            CreatedTime = DateTime.UtcNow;
            Version = 1;
        }

        /// <summary>
        /// 创建角色的工厂方法
        /// </summary>
        public static Role Create(
            string name,
            string code,
            int orderNum = 0,
            int dataScope = 1,
            bool menuCheckStrictly = true,
            bool deptCheckStrictly = true,
            int status = 0,
            string remark = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("角色名称不能为空", nameof(name));

            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("角色编码不能为空", nameof(code));

            return new Role
            {
                Name = name,
                NormalizedName = name.ToUpper(),
                Code = code,
                OrderNum = orderNum,
                DataScope = dataScope,
                MenuCheckStrictly = menuCheckStrictly,
                DeptCheckStrictly = deptCheckStrictly,
                Status = status,
                Remark = remark,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        public void Update(
            string name,
            string code,
            int orderNum = 0,
            int dataScope = 1,
            bool menuCheckStrictly = true,
            bool deptCheckStrictly = true,
            int status = 0,
            string remark = null,
            long? modifiedBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("角色名称不能为空", nameof(name));

            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("角色编码不能为空", nameof(code));

            Name = name;
            NormalizedName = name.ToUpper();
            Code = code;
            OrderNum = orderNum;
            DataScope = dataScope;
            MenuCheckStrictly = menuCheckStrictly;
            DeptCheckStrictly = deptCheckStrictly;
            Status = status;
            Remark = remark;
            ConcurrencyStamp = Guid.NewGuid().ToString();

            UpdateModificationInfo(modifiedBy);
        }

        /// <summary>
        /// 启用角色
        /// </summary>
        public void Enable(long? modifiedBy = null)
        {
            Status = 0;
            UpdateModificationInfo(modifiedBy);
        }

        /// <summary>
        /// 停用角色
        /// </summary>
        public void Disable(long? modifiedBy = null)
        {
            Status = 1;
            UpdateModificationInfo(modifiedBy);
        }

        /// <summary>
        /// 添加角色菜单关联
        /// </summary>
        public void AddRoleMenu(RoleMenu roleMenu)
        {
            if (roleMenu == null)
                throw new ArgumentNullException(nameof(roleMenu));

            if (_roleMenus.Any(rm => rm.MenuId == roleMenu.MenuId))
                return; // 已存在相同的菜单关联，不重复添加

            _roleMenus.Add(roleMenu);
            roleMenu.SetRole(this);
        }

        /// <summary>
        /// 移除角色菜单关联
        /// </summary>
        public void RemoveRoleMenu(RoleMenu roleMenu)
        {
            if (roleMenu == null)
                throw new ArgumentNullException(nameof(roleMenu));

            _roleMenus.Remove(roleMenu);
        }

        /// <summary>
        /// 清空角色菜单关联
        /// </summary>
        public void ClearRoleMenus()
        {
            _roleMenus.Clear();
        }

        /// <summary>
        /// 添加角色部门关联
        /// </summary>
        public void AddRoleDept(RoleDept roleDept)
        {
            if (roleDept == null)
                throw new ArgumentNullException(nameof(roleDept));

            if (_roleDepts.Any(rd => rd.DeptId == roleDept.DeptId))
                return; // 已存在相同的部门关联，不重复添加

            _roleDepts.Add(roleDept);
            roleDept.SetRole(this);
        }

        /// <summary>
        /// 移除角色部门关联
        /// </summary>
        public void RemoveRoleDept(RoleDept roleDept)
        {
            if (roleDept == null)
                throw new ArgumentNullException(nameof(roleDept));

            _roleDepts.Remove(roleDept);
        }

        /// <summary>
        /// 清空角色部门关联
        /// </summary>
        public void ClearRoleDepts()
        {
            _roleDepts.Clear();
        }

        /// <summary>
        /// 设置角色的菜单权限
        /// </summary>
        public void SetMenuPermissions(IEnumerable<long> menuIds, long? modifiedBy = null)
        {
            if (menuIds == null)
                throw new ArgumentNullException(nameof(menuIds));

            // 清空现有菜单关联
            ClearRoleMenus();

            // 添加新的菜单关联
            foreach (var menuId in menuIds)
            {
                var roleMenu = RoleMenu.Create(Id, menuId);
                AddRoleMenu(roleMenu);
            }

            UpdateModificationInfo(modifiedBy);
        }

        /// <summary>
        /// 设置角色的部门数据权限
        /// </summary>
        public void SetDeptPermissions(IEnumerable<long> deptIds, int dataScope, long? modifiedBy = null)
        {
            if (deptIds == null && dataScope == 2) // 自定义数据权限需要指定部门
                throw new ArgumentNullException(nameof(deptIds));

            // 更新数据范围
            DataScope = dataScope;

            // 清空现有部门关联
            ClearRoleDepts();

            // 如果是自定义数据权限，添加新的部门关联
            if (dataScope == 2)
            {
                foreach (var deptId in deptIds)
                {
                    var roleDept = RoleDept.Create(Id, deptId);
                    AddRoleDept(roleDept);
                }
            }

            UpdateModificationInfo(modifiedBy);
        }

        /// <summary>
        /// 标记实体为已删除
        /// </summary>
        public void MarkAsDeleted(long? deletedBy = null)
        {
            IsDeleted = true;
            DeletedTime = DateTime.UtcNow;
            DeletedBy = deletedBy;
            IncrementVersion();
        }

        /// <summary>
        /// 更新实体修改信息
        /// </summary>
        public void UpdateModificationInfo(long? modifiedBy = null)
        {
            LastModifiedTime = DateTime.UtcNow;
            LastModifiedBy = modifiedBy;
            IncrementVersion();
        }

        /// <summary>
        /// 增加版本号
        /// </summary>
        private void IncrementVersion()
        {
            Version++;
        }
    }
}
