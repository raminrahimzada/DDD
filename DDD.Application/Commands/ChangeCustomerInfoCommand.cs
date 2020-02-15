using System;

namespace DDD.Application.Commands
{
    public class ChangeCustomerInfoCommand: CommandBase
    {
        public Guid CustomerId { get;private set; }
        public string NewName { get; private set; }

        public ChangeCustomerInfoCommand(Guid customerId, string newName)
        {
            CustomerId = customerId;
            NewName = newName;
        }
    }
}
