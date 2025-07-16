using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.Auth;
using RuoYi.Domain.Events.Auth;
using RuoYi.Domain.Events;
using RuoYi.Domain.Repositories;

namespace RuoYi.Domain.Services
{
    /// <summary>
    /// 用户领域服务实现
    /// </summary>
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDomainEventDispatcher _eventDispatcher;

        public UserDomainService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IDomainEventDispatcher eventDispatcher)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _eventDispatcher = eventDispatcher;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        public async Task<User> CreateUserAsync(
            string userName,
            string email,
            string fullName,
            string phoneNumber = null,
            string department = null,
            string position = null,
            int sex = 0,
            string avatar = null,
            string remark = null)
        {
            // 检查用户名是否已存在
            if (await _userRepository.ExistsAsync(u => u.UserName == userName))
                throw new InvalidOperationException($"用户名 '{userName}' 已存在");

            // 检查电子邮件是否已存在
            if (await _userRepository.ExistsAsync(u => u.Email == email))
                throw new InvalidOperationException($"电子邮件 '{email}' 已被使用");

            // 创建用户
            var user = User.Create(
                userName,
                email,
                fullName,
                phoneNumber,
                department,
                position,
                sex,
                avatar,
                remark);

            // 添加用户创建事件
            var createdEvent = new UserCreatedEvent(user);
            await _eventDispatcher.DispatchAsync(createdEvent);

            return user;
        }

        /// <summary>
        /// 分配用户角色
        /// </summary>
        public async Task AssignRolesToUserAsync(User user, params long[] roleIds)
        {
            //if (user == null)
            //    throw new ArgumentNullException(nameof(user));

            //if (roleIds == null || roleIds.Length == 0)
            //    return;

            //// 获取所有角色
            //var roles = await Task.WhenAll(roleIds.Select(id => _roleRepository.GetByIdAsync(id)));

            //// 清空用户现有角色
            //user.ClearUserRoles();

            //// 添加新角色
            //foreach (var role in roles.Where(r => r != null))
            //{
            //    var userRole = UserRole.Create(user.Id, role.Id);
            //    user.AddUserRole(userRole);
            //}
        }

        /// <summary>
        /// 验证用户密码
        /// </summary>
        public Task<bool> ValidatePasswordAsync(User user, string password)
        {
            // 密码验证应该由Identity框架处理
            // 这里只是一个占位方法
            throw new NotImplementedException("密码验证应由Identity框架处理");
        }
    }
}
