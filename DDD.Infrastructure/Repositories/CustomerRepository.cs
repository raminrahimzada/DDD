using System;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Aggregates.CustomerAggregate;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Repositories
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
            await _dbContext.Customers.AddAsync(customer.ToDAO());            
        }

        public async Task Update(Customer customer)
        {
            var old = await _dbContext.Customers.FirstAsync(x => x.Id == customer.Id);
            old.Name = customer.Name;
            old.Balance = customer.Balance;
            _dbContext.Customers.Update(old);
        }

        public async Task<Customer> FindByIdAsync(Guid id)
        {
            var dao = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return dao.ToEntity();
        }
    }
}
