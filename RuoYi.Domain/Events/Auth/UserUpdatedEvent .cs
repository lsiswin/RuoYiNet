using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.Auth;

namespace RuoYi.Domain.Events.Auth
{
    /// <summary>
    /// 用户更新事件
    /// </summary>
    public class UserUpdatedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; }

        public UserUpdatedEvent(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            UserId = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            FullName = user.FullName;
        }
    }
}
