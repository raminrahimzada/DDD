using System;
using System.Collections.Generic;

namespace DDD.Base
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
        int Version { get; }
        DateTime CreatedUtc { get; }

        IEnumerable<IEvent> DequeueUncommittedEvents();
    }
}