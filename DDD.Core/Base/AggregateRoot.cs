using System;
using System.Collections.Generic;
using DDD.Base;

namespace DDD.Core.Base
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public int Version { get; protected set; }
        public DateTime CreatedUtc { get; protected set; }
        public virtual string Name => "";

        [NonSerialized]
        private readonly Queue<AbstractEvent> _uncommittedEvents = new Queue<AbstractEvent>();

        protected AggregateRoot()
        { }

        protected AggregateRoot(Guid id)
        {
            Id = id;
        }
        IEnumerable<IEvent> IAggregateRoot.DequeueUncommittedEvents()
        {
            while (_uncommittedEvents.Count>0)
            {
                yield return _uncommittedEvents.Dequeue();
            }
        }

        protected virtual void ApplyEvent(AbstractEvent @event)
        {
            Version++;
            _uncommittedEvents.Enqueue(@event);
        }
    }
}