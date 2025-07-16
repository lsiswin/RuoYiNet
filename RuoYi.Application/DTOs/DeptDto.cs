using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Application.DTOs
{
    /// <summary>
    /// 部门DTO
    /// </summary>
    public class DeptDto
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 父部门ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 祖级列表
        /// </summary>
        public string Ancestors { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Leader { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 状态（0：正常，1：停用）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 子部门
        /// </summary>
        public List<DeptDto> Children { get; set; }
    }
}
