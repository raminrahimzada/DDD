using System;
using System.Threading.Tasks;
using DDD.Domain.Aggregates.CustomerAggregate;
using Microsoft.EntityFrameworkCore;

namespace DDD.Application.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly AppDatabaseContext _dbContext;
        public CustomerRepository(AppDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);            
        }

        public void Update(Customer customer)
        {
            _dbContext.Customers.Update(customer);
        }

        public Task<Customer> FindByIdAsync(Guid id)
        {
            return _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
