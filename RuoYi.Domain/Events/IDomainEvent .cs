using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RuoYi.Domain.Events
{
    /// <summary>
    /// 领域事件接口
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// 事件发生时间
        /// </summary>
        DateTime OccurredOn { get; }

        /// <summary>
        /// 事件ID
        /// </summary>
        Guid EventId { get; }
    }
}
