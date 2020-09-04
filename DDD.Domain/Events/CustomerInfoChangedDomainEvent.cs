using System;
using DDD.Core.Base;

namespace DDD.Core.Events
{
    public class CustomerInfoChangedDomainEvent: DomainEvent
    {
        public Guid CustomerId { get; }
        public string OldName { get; }
        public string NewName { get; }

        public CustomerInfoChangedDomainEvent(Guid customerId, string oldName, string newName)
        {
            CustomerId = customerId;
            OldName = oldName;
            NewName = newName;
        }
    }
}
