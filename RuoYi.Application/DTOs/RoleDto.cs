using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Application.DTOs
{
    /// <summary>
    /// 角色DTO
    /// </summary>
    public class RoleDto
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 数据范围（1：全部数据权限 2：自定义数据权限 3：本部门数据权限 4：本部门及以下数据权限 5：仅本人数据权限）
        /// </summary>
        public int DataScope { get; set; }

        /// <summary>
        /// 菜单树选择项是否关联显示
        /// </summary>
        public bool MenuCheckStrictly { get; set; }

        /// <summary>
        /// 部门树选择项是否关联显示
        /// </summary>
        public bool DeptCheckStrictly { get; set; }

        /// <summary>
        /// 状态（0：正常，1：停用）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 菜单ID列表
        /// </summary>
        public List<long> MenuIds { get; set; }

        /// <summary>
        /// 部门ID列表
        /// </summary>
        public List<long> DeptIds { get; set; }
    }

}
