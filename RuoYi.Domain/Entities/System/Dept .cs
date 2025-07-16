using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Common.Enums;
using RuoYi.Domain.Entities.Auth;

namespace RuoYi.Domain.Entities.System
{
    /// <summary>
    /// 部门实体
    /// </summary>
    public class Dept : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; } = string.Empty;

        /// <summary>
        /// 父部门ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 祖级列表
        /// </summary>
        public string Ancestors { get; set; } = string.Empty;

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string? Leader { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 部门状态
        /// </summary>
        public DeptStatus Status { get; set; } = DeptStatus.Normal;

        /// <summary>
        /// 删除标志
        /// </summary>
        public bool DelFlag { get; set; } = false;

        // 导航属性
        /// <summary>
        /// 父部门
        /// </summary>
        public virtual Dept? Parent { get; set; }

        /// <summary>
        /// 子部门集合
        /// </summary>
        public virtual ICollection<Dept> Children { get; set; } = new List<Dept>();

        /// <summary>
        /// 部门用户集合
        /// </summary>
        public virtual ICollection<User> Users { get; set; } = new List<User>();

        /// <summary>
        /// 角色部门关联集合
        /// </summary>
        public virtual ICollection<RoleDept> RoleDepts { get; set; } = new List<RoleDept>();

        // 领域方法

        /// <summary>
        /// 是否为根部门
        /// </summary>
        public bool IsRoot() => ParentId == null || ParentId == 0;

        /// <summary>
        /// 是否激活状态
        /// </summary>
        public bool IsActive() => Status == DeptStatus.Normal && !DelFlag;

        /// <summary>
        /// 更新部门信息
        /// </summary>
        public void UpdateInfo(string deptName, long? parentId, int orderNum, string? leader = null,
            string? phone = null, string? email = null)
        {
            DeptName = deptName;
            ParentId = parentId;
            OrderNum = orderNum;
            Leader = leader;
            Phone = phone;
            Email = email;
            UpdateModificationInfo();
        }

        /// <summary>
        /// 更新祖级列表
        /// </summary>
        public void UpdateAncestors(string ancestors)
        {
            Ancestors = ancestors;
            UpdateModificationInfo();
        }

        /// <summary>
        /// 启用部门
        /// </summary>
        public void Enable()
        {
            Status = DeptStatus.Normal;
            UpdateModificationInfo();
        }

        /// <summary>
        /// 停用部门
        /// </summary>
        public void Disable()
        {
            Status = DeptStatus.Disabled;
            UpdateModificationInfo();
        }

        /// <summary>
        /// 软删除部门
        /// </summary>
        public void SoftDelete()
        {
            DelFlag = true;
            UpdateModificationInfo();
        }

        /// <summary>
        /// 恢复部门
        /// </summary>
        public void Restore()
        {
            DelFlag = false;
            UpdateModificationInfo();
        }

        /// <summary>
        /// 检查是否为指定部门的祖先
        /// </summary>
        public bool IsAncestorOf(Dept dept)
        {
            return dept.Ancestors.Contains($",{Id},") || dept.Ancestors.StartsWith($"{Id},");
        }

        /// <summary>
        /// 检查是否为指定部门的后代
        /// </summary>
        public bool IsDescendantOf(Dept dept)
        {
            return Ancestors.Contains($",{dept.Id},") || Ancestors.StartsWith($"{dept.Id},");
        }

        /// <summary>
        /// 获取部门层级
        /// </summary>
        public int GetLevel()
        {
            if (string.IsNullOrEmpty(Ancestors))
                return 1;
            return Ancestors.Split(',', StringSplitOptions.RemoveEmptyEntries).Length + 1;
        }
    }
}
