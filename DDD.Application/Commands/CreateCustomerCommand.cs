using System;
using DDD.Core.Base;

namespace DDD.Application.Commands
{
    public class CreateCustomerCommand : ICommand 
    {
        public Guid Id { get; }
        public string Name { get; }

        public CreateCustomerCommand(Guid id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}