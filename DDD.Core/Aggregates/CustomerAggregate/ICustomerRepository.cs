using System;
using System.Threading.Tasks;
using DDD.Base;

namespace DDD.Core.Aggregates.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task Add(Customer customer);
        void Update(Customer customer);
        Task<Customer> FindByIdAsync(Guid id);
    }
}