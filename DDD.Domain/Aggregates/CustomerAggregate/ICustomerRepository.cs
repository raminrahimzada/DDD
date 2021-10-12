using System;
using System.Threading.Tasks;
using DDD.Domain.Base;

namespace DDD.Domain.Aggregates.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task<Customer> FindByIdAsync(Guid id);
    }
}