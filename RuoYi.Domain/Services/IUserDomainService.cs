using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.Auth;

namespace RuoYi.Domain.Services
{
    /// <summary>
    /// 用户领域服务接口
    /// </summary>
    public interface IUserDomainService
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="email">电子邮件</param>
        /// <param name="fullName">姓名</param>
        /// <param name="phoneNumber">电话号码</param>
        /// <param name="department">部门</param>
        /// <param name="position">职位</param>
        /// <param name="sex">性别</param>
        /// <param name="avatar">头像</param>
        /// <param name="remark">备注</param>
        /// <returns>创建的用户</returns>
        Task<User> CreateUserAsync(
            string userName,
            string email,
            string fullName,
            string phoneNumber = null,
            string department = null,
            string position = null,
            int sex = 0,
            string avatar = null,
            string remark = null);

        /// <summary>
        /// 分配用户角色
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="roleIds">角色ID集合</param>
        Task AssignRolesToUserAsync(User user, params long[] roleIds);

        /// <summary>
        /// 验证用户密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        /// <returns>是否验证成功</returns>
        Task<bool> ValidatePasswordAsync(User user, string password);
    }
}
