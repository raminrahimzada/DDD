using System;

namespace DDD.Infrastructure.Models
{
    public class TransactionDAO : BaseDAO
    {
        public CustomerDAO FromCustomer { get;  set; }
        public CustomerDAO ToCustomer { get;  set; }
        public decimal Amount { get;  set; }
        public DateTime When { get;  set; }
    }
}