using System;
using System.Collections.Generic;

namespace DDD.Domain.Base
{
    public interface IDomainEvent
    {

    }
    public interface IAggregateRoot
    {
        Guid Id { get; }
        int Version { get; }
        DateTime CreatedUtc { get; }

        IEnumerable<IDomainEvent> DequeueUncommittedEvents();
    }
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
    public abstract class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public int Version { get; protected set; }
        public DateTime CreatedUtc { get; protected set; }
        //public virtual string Name => "";

        [NonSerialized]
        private readonly Queue<DomainEvent> _uncommittedEvents = new Queue<DomainEvent>();

        protected AggregateRoot()
        { }

        protected AggregateRoot(Guid id)
        {
            Id = id;
        }
        IEnumerable<IDomainEvent> IAggregateRoot.DequeueUncommittedEvents()
        {
            while (_uncommittedEvents.Count>0)
            {
                yield return _uncommittedEvents.Dequeue();
            }
        }

        protected virtual void ApplyEvent(DomainEvent domainEvent)
        {
            Version++;
            _uncommittedEvents.Enqueue(domainEvent);
        }
    }
}