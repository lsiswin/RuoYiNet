using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Application.DTOs.Models
{
    /// <summary>
    /// 创建用户请求
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(100, ErrorMessage = "密码长度必须至少为6个字符", MinimumLength = 6)]
        public string Password { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [Required(ErrorMessage = "电子邮件不能为空")]
        [EmailAddress(ErrorMessage = "电子邮件格式不正确")]
        public string Email { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]
        public string FullName { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Phone(ErrorMessage = "电话号码格式不正确")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 性别（0：男，1：女，2：未知）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 角色ID列表
        /// </summary>
        public long[] RoleIds { get; set; }
    }
}
