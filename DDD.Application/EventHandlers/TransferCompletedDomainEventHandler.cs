using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Base;
using DDD.Domain;
using DDD.Domain.Aggregates.TransactionAggregate;
using DDD.Domain.Events;

namespace DDD.Application.EventHandlers
{
    public class TransferCompletedDomainEventHandler :
        IEventHandler<TransferCompletedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferCompletedDomainEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task Handle(TransferCompletedDomainEvent notification, CancellationToken cancellationToken)
        {
            var transaction =
                new Transaction(Guid.NewGuid(), notification.From, notification.To, notification.Amount, DateTime.Now);
            _unitOfWork.TransactionRepo.Add(transaction);
            return _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}