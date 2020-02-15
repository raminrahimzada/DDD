using System;
using DDD.Core.Base;
using DDD.Core.Events;
using DDD.Core.Exceptions;

namespace DDD.Core.Aggregates.CustomerAggregate
{
    public class Customer:Entity,IAggregateRoot
    {
        public string Name { get; private set; }

        public decimal Balance { get; private set; }

        public Customer(Guid id,string name, decimal balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }

        public void ChangeInfo(string newName)
        {
            if (newName == Name) return;
            
            AddDomainEvent(new CustomerInfoChangedDomainEvent(Id, Name, newName));
            Name = newName;
        }

        public void GiftMoney(Customer otherCustomer,decimal amount)
        {
            var oldAmount = Balance;
            var newAmount = Balance - amount;

            if (oldAmount < amount) throw new NotEnoughMoneyDomainException();

            Balance = newAmount;
            otherCustomer.AcceptGift(amount);


            AddDomainEvent(new CustomerBalanceChangedDomainEvent(Id, oldAmount, newAmount));
            AddDomainEvent(new TransferCompletedDomainEvent(this, otherCustomer, amount));
        }

        public void AcceptGift(decimal amount)
        {
            var oldAmount = Balance;
            var newAmount = Balance + amount;
            Balance = newAmount;

            AddDomainEvent(new CustomerBalanceChangedDomainEvent(Id, oldAmount, newAmount));
        }
    }
}
