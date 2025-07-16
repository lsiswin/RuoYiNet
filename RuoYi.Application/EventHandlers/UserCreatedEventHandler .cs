using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RuoYi.Domain.Events;
using RuoYi.Domain.Events.Auth;

namespace RuoYi.Application.EventHandlers
{
    /// <summary>
    /// 用户创建事件处理器
    /// </summary>
    public class UserCreatedEventHandler : IDomainEventHandler<UserCreatedEvent>
    {
        private readonly ILogger<UserCreatedEventHandler> _logger;

        public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 处理用户创建事件
        /// </summary>
        public Task HandleAsync(UserCreatedEvent domainEvent, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"用户创建: ID={domainEvent.UserId}, 用户名={domainEvent.UserName}, 邮箱={domainEvent.Email}");

            // 可以在这里执行其他操作，如发送欢迎邮件、初始化用户配置等

            return Task.CompletedTask;
        }
    }
}
