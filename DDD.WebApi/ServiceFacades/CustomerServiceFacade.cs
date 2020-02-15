using System;
using System.Threading.Tasks;
using DDD.Application;
using DDD.Application.Commands;
using DDD.Application.Queries;
using DDD.WebApi.DTO;
using DDD.WebApi.ViewModels;

namespace DDD.WebApi.ServiceFacades
{
    public class CustomerServiceFacade
    {
        private readonly ICustomMediator _mediator;

        public CustomerServiceFacade(ICustomMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResponseModel<Guid>> CreateCustomer(CreateCustomerViewModel model)
        {
            try
            {
                var id = Guid.NewGuid();
                var command = new CreateCustomerCommand(id, model.Name);
                await _mediator.Send(command);
                return ResponseModel<Guid>.Success(id);
            }
            catch (Exception e)
            {
                return ResponseModel<Guid>.Failure(e);
            }
        }

        public async Task<ResponseModel> ChangeInfo(ChangeCustomerInfoViewModel model)
        {
            try
            {
                var command = new ChangeCustomerInfoCommand(model.CustomerId, model.NewName);
                await _mediator.Send(command);
                return ResponseModel.Success();
            }
            catch (Exception e)
            {
                return ResponseModel.Failure(e);
            }
        }

        public async Task<ResponseModel> MakeGift(Guid fromCustomerId, Guid toCustomerId, decimal amount)
        {
            try
            {
                var command=new MakeGiftCommand(fromCustomerId, toCustomerId, amount);
                await _mediator.Send(command);
                return ResponseModel.Success();
            }
            catch (Exception e)
            {
                return ResponseModel.Failure(e);
            }
        }

        public async Task<ResponseModel<CustomerDTO>> GetInfo(GetCustomerInfoViewModel model)
        {
            try
            {
                var query = new GetCustomerInfoQuery(model.CustomerId);
                var result = await _mediator.Send(query);
                var dto=new CustomerDTO
                {
                    Id = result.Id,
                    Balance = result.Balance,
                    Name = result.Name
                };
                return ResponseModel<CustomerDTO>.Success(dto);
            }
            catch (Exception e)
            {
                return ResponseModel<CustomerDTO>.Failure(e);
            }
        }
    }
}
