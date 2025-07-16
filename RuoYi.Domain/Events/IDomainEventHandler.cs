using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Domain.Events
{
    /// <summary>
    /// 领域事件处理器接口
    /// </summary>
    /// <typeparam name="TEvent">领域事件类型</typeparam>
    public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
    {
        /// <summary>
        /// 处理领域事件
        /// </summary>
        /// <param name="domainEvent">领域事件</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task HandleAsync(TEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
