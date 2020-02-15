using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Core;
using DDD.Core.Aggregates.TransactionAggregate;
using DDD.Core.Base;
using DDD.Core.Events;

namespace DDD.Application.DomainEventHandlers
{
    public class TransferCompletedDomainEventHandler : IDomainEventHandler<TransferCompletedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferCompletedDomainEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TransferCompletedDomainEvent notification, CancellationToken cancellationToken)
        {
            var transaction =
                new Transaction(notification.From.Id, notification.To.Id, notification.Amount, DateTime.Now);
            _unitOfWork.TransactionRepo.Add(transaction);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}