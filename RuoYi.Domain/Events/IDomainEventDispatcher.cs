using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Domain.Events
{
    /// <summary>
    /// 领域事件分发器接口
    /// </summary>
    public interface IDomainEventDispatcher
    {
        /// <summary>
        /// 分发领域事件
        /// </summary>
        /// <param name="domainEvent">领域事件</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
