using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuoYi.Domain.Events;

namespace RuoYi.Domain.Entities
{
    /// <summary>
    /// 支持领域事件的实体基类
    /// </summary>
    public abstract class Entity : BaseEntity
    {
        private List<IDomainEvent> _domainEvents;

        /// <summary>
        /// 领域事件集合
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        /// <summary>
        /// 添加领域事件
        /// </summary>
        /// <param name="domainEvent">领域事件</param>
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        /// <summary>
        /// 移除领域事件
        /// </summary>
        /// <param name="domainEvent">领域事件</param>
        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        /// <summary>
        /// 清空领域事件
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
