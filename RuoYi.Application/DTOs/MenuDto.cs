using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Application.DTOs
{
    /// <summary>
    /// 菜单DTO
    /// </summary>
    public class MenuDto
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 组件路径
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 路由参数
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// 是否为外链（0是 1否）
        /// </summary>
        public bool IsFrame { get; set; }

        /// <summary>
        /// 是否缓存（0缓存 1不缓存）
        /// </summary>
        public bool IsCache { get; set; }

        /// <summary>
        /// 菜单类型（M目录 C菜单 F按钮）
        /// </summary>
        public string MenuType { get; set; }

        /// <summary>
        /// 菜单状态（0显示 1隐藏）
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// 菜单状态（0正常 1停用）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 权限标识
        /// </summary>
        public string Perms { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuDto> Children { get; set; }
    }
}
