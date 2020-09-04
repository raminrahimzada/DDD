using System;
using DDD.Base;
using MediatR;

namespace DDD.Core.Base
{
    public class AbstractCommand : ICommand, IRequest<ExecutionResult>
    {
        public Guid Id { get; set; }

        public AbstractCommand()
        {
            Id = Guid.NewGuid();
        }
    }
}