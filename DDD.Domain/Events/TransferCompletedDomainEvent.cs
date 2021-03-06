﻿using System;
using DDD.Domain.Base;

namespace DDD.Domain.Events
{
    public class TransferCompletedDomainEvent : DomainEvent
    {
        public Guid From { get; }
        public Guid To { get; }

        public decimal Amount { get; }

        public TransferCompletedDomainEvent(Guid @from, Guid to, decimal amount)
        {
            From = @from;
            To = to;
            Amount = amount;
        }
    }
}