using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Entities.Auth;

namespace RuoYi.Domain.Events.Auth
{
    /// <summary>
    /// 角色创建事件
    /// </summary>
    public class RoleCreatedEvent : DomainEvent
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; }

        public RoleCreatedEvent(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            RoleId = role.Id;
            RoleName = role.Name;
            RoleCode = role.Code;
        }
    }
}
