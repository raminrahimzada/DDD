using System;

namespace DDD.Application.Commands
{
    public class MakeGiftCommand : CommandBase
    {
        public Guid FromCustomerId { get; private set; }
        public Guid ToCustomerId { get; private set; }
        public decimal Amount { get; private set; }

        public MakeGiftCommand(Guid fromCustomerId, Guid toCustomerId, decimal amount)
        {
            FromCustomerId = fromCustomerId;
            ToCustomerId = toCustomerId;
            Amount = amount;
        }
    }
}