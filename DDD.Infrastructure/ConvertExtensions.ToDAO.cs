


using DDD.Domain.Aggregates.CustomerAggregate;
using DDD.Domain.Aggregates.EventLogAggregate;
using DDD.Domain.Aggregates.TransactionAggregate;
using DDD.Infrastructure.Models;

namespace DDD.Infrastructure
{
    public static partial class ConvertExtensions
    {
        public static CustomerDAO ToDAO(this Customer entity)
        {
            var dao = new CustomerDAO();
            dao.Id = entity.Id;
            dao.Name = entity.Name;
            dao.Balance = entity.Balance;
            return dao;
        }

        public static EventLogDAO ToDAO(this EventLog entity)
        {
            var dao = new EventLogDAO();
            dao.Id = entity.Id;
            dao.Data = entity.Data;
            dao.LogType = (byte)entity.LogType;
            dao.Type = entity.Type;
            dao.When = entity.When;
            return dao;
        }
        public static TransactionDAO ToDAO(this Transaction entity)
        {
            var dao = new TransactionDAO();
            dao.Id = entity.Id;
            dao.Amount = entity.Amount;
            dao.FromCustomer = new CustomerDAO(){Id = entity.FromCustomerId };
            dao.ToCustomer = new CustomerDAO(){Id = entity.ToCustomerId };
            dao.When = entity.When;
            return dao;
        }
    }
}
