using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.Auth;

namespace RuoYi.Domain.Repositories
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户</returns>
        Task<User> GetByUserNameAsync(string userName);

        /// <summary>
        /// 根据规范化用户名获取用户
        /// </summary>
        /// <param name="normalizedUserName">规范化用户名</param>
        /// <returns>用户</returns>
        Task<User> GetByNormalizedUserNameAsync(string normalizedUserName);

        /// <summary>
        /// 根据电子邮件获取用户
        /// </summary>
        /// <param name="email">电子邮件</param>
        /// <returns>用户</returns>
        Task<User> GetByEmailAsync(string email);

        /// <summary>
        /// 根据规范化电子邮件获取用户
        /// </summary>
        /// <param name="normalizedEmail">规范化电子邮件</param>
        /// <returns>用户</returns>
        Task<User> GetByNormalizedEmailAsync(string normalizedEmail);

        /// <summary>
        /// 获取用户的角色
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>角色集合</returns>
        Task<IEnumerable<Role>> GetUserRolesAsync(long userId);

        /// <summary>
        /// 获取部门下的所有用户
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <returns>用户集合</returns>
        Task<IEnumerable<User>> GetUsersByDeptIdAsync(long deptId);
    }
}
