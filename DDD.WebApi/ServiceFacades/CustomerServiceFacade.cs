using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Commands;
using DDD.Application.Queries;
using DDD.Base;
using DDD.Core.Exceptions;
using DDD.WebApi.DTO;
using DDD.WebApi.ViewModels;

namespace DDD.WebApi.ServiceFacades
{
    public class CustomerServiceFacade
    {
        private readonly IGenericBus _bus;

        public CustomerServiceFacade(IGenericBus bus)
        {
            _bus = bus;
        }
        public async Task<ResponseModel<Guid>> CreateCustomer(CreateCustomerViewModel model)
        {
            try
            {
                var id = Guid.NewGuid();
                var command = new CreateCustomer.Command(id, model.Name);
                var result = await _bus.Send(command, CancellationToken.None);
                if (result.IsSucceed)
                {
                    return ResponseModel<Guid>.Success(id);
                }
                return ResponseModel<Guid>.Failure(new Exception());
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
                var command = new ChangeCustomerInfo.Command(model.CustomerId, model.NewName);
                var result = await _bus.Send(command,CancellationToken.None);
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
                var command =new MakeGift.Command(fromCustomerId, toCustomerId, amount);
                await _bus.Send(command, CancellationToken.None);
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
                var query = new GetCustomerInfo.Query(model.CustomerId);
                var result = await _bus.Send(query, CancellationToken.None);
                if (result == null)
                    return ResponseModel<CustomerDTO>.Failure(new EntityNotFoundException(model.CustomerId));

                var dto=new CustomerDTO
                {
                    Id = result.CustomerId,
                    Balance = result.CustomerBalance,
                    Name = result.CustomerName
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
