using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Base;
using DDD.Core;
using DDD.Core.Aggregates.TransactionAggregate;
using DDD.Core.Events;

namespace DDD.Application.EventHandlers
{
    public class TransferCompletedDomainEventHandler :
        AbstractEventHandler<TransferCompletedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferCompletedDomainEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override Task Handle(TransferCompletedDomainEvent notification, CancellationToken cancellationToken)
        {
            var transaction =
                new Transaction(Guid.NewGuid(), notification.From, notification.To, notification.Amount, DateTime.Now);
            _unitOfWork.TransactionRepo.Add(transaction);
            return _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}