using System;
using System.Threading.Tasks;
using DDD.Application.Commands;
using DDD.Application.Queries;
using DDD.WebApi.DTO;
using DDD.WebApi.ViewModels;
using MediatR;

namespace DDD.WebApi.Services
{
    public class CustomerService
    {
        private readonly IMediator _mediator;

        public CustomerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Guid> CreateCustomer(CreateCustomerViewModel model)
        {
            var id = Guid.NewGuid();
            var command = new CreateCustomerCommand(id, model.Name);
            await _mediator.Send(command);
            return id;
        }

        public async Task ChangeInfo(ChangeCustomerInfoViewModel model)
        {
            var command = new ChangeCustomerInfoCommand(model.CustomerId, model.NewName);
            await _mediator.Send(command);
        }

        public async Task MakeGift(Guid fromCustomerId, Guid toCustomerId, decimal amount)
        {
            var command=new MakeGiftCommand(fromCustomerId, toCustomerId, amount);
            await _mediator.Send(command);
        }

        public async Task<CustomerDTO> GetInfo(GetCustomerInfoViewModel model)
        {
            var query = new GetCustomerInfoQuery(model.CustomerId);
            var result = await _mediator.Send(query);
            return new CustomerDTO
            {
                Id = result.Id,
                Balance = result.Balance,
                Name = result.Name
            };
        }
    }
}
