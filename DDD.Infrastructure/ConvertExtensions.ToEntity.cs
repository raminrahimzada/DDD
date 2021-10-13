


using DDD.Domain.Aggregates.CustomerAggregate;
using DDD.Domain.Aggregates.EventLogAggregate;
using DDD.Domain.Aggregates.TransactionAggregate;
using DDD.Infrastructure.Models;

namespace DDD.Infrastructure
{
    public static partial class ConvertExtensions
    {
        public static Customer ToEntity(this CustomerDAO dao)
        {
            if (dao == null) return null;
            return new Customer(dao.Id, dao.Name, dao.Balance);
        }

        public static EventLog ToEntity(this EventLogDAO dao)
        {
            if (dao == null) return null;
            return new EventLog(dao.Id,dao.LogType.ToEnum<EventLog.EventLogTypes>(), dao.Type, dao.When, dao.Data);
        }
        public static Transaction ToEntity(this TransactionDAO dao)
        {
            if (dao == null) return null;
            return new Transaction(dao.FromCustomer.Id, dao.FromCustomer.Id, dao.ToCustomer.Id, dao.Amount, dao.When);
        }
    }
}