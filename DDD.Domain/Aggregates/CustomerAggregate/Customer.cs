using System;
using DDD.Domain.Base;
using DDD.Domain.Events;
using DDD.Domain.Exceptions;

namespace DDD.Domain.Aggregates.CustomerAggregate
{
    public class Customer: AggregateRoot,IAggregateRoot
    {
        public Customer(Guid id, string customerName, decimal balance) : base(id)
        {
            CustomerName = customerName;
            Balance = balance;
        }

        public string CustomerName { get;private  set; }

        public decimal Balance { get;private set; }

        public void ChangeInfo(string newName)
        {
            if (newName == CustomerName) return;
            ApplyEvent(new CustomerInfoChangedDomainEvent(Id, CustomerName, newName));
            CustomerName = newName;
        }

        public void GiftMoney(Customer otherCustomer,decimal amount)
        {
            var oldAmount = Balance;
            var newAmount = Balance - amount;

            if (oldAmount < amount) throw new NotEnoughMoneyDomainException();

            Balance = newAmount;
            otherCustomer.AcceptGift(amount);


            ApplyEvent(new CustomerBalanceChangedDomainEvent(Id, oldAmount, newAmount));
            ApplyEvent(new TransferCompletedDomainEvent(Id, otherCustomer.Id, amount));
        }

        public void AcceptGift(decimal amount)
        {
            var oldAmount = Balance;
            var newAmount = Balance + amount;
            Balance = newAmount;

            ApplyEvent(new CustomerBalanceChangedDomainEvent(Id, oldAmount, newAmount));
        }
    }
}
