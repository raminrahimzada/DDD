using System;
using DDD.Domain.Base;
using DDD.Domain.Events;
using DDD.Domain.Exceptions;

namespace DDD.Domain.Aggregates.CustomerAggregate
{
    public class Customer: AggregateRoot
    {
        public Customer(Guid id, string name, decimal balance) : base(id)
        {
            Name = name;
            Balance = balance;
        }

        public string Name { get;private  set; }

        public decimal Balance { get;private set; }

        public void ChangeInfo(string newName)
        {
            if (newName == Name) return;
            ApplyEvent(new CustomerInfoChangedDomainEvent(Id, Name, newName));
            Name = newName;
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
