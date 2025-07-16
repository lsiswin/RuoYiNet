using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuoYi.Domain.Events
{

    /// <summary>
    /// 领域事件基类
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        /// <summary>
        /// 事件发生时间
        /// </summary>
        public DateTime OccurredOn { get; }

        /// <summary>
        /// 事件ID
        /// </summary>
        public Guid EventId { get; }

        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }

}
