using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Application;
using DDD.Domain;
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
        public async Task<ExecutionResult<Guid>> CreateCustomer(CreateCustomerViewModel model)
        {
            try
            {
                var id = Guid.NewGuid();
                var command = new CreateCustomerCommand(id, model.Name);
                await _bus.Send(command, CancellationToken.None);
                return ExecutionResult.Success(id);
            }
            catch (Exception e)
            {
                return ExecutionResult<Guid>.Fail(e);
            }
        }

        public async Task<ExecutionResult> ChangeInfo(ChangeCustomerInfoViewModel model)
        {
            try
            {
                var command = new ChangeCustomerInfoCommand(model.CustomerId, model.NewName);
                return await _bus.Send(command,CancellationToken.None);
            }
            catch (Exception e)
            {
                return ExecutionResult.Fail(e);
            }
        }

        public async Task<ExecutionResult> MakeGift(MakeGiftViewModel model)
        {
            try
            {
                var command =new MakeGiftCommand(model.FromCustomerId, model.ToCustomerId, model.Amount);
                return await _bus.Send(command, CancellationToken.None);
            }
            catch (Exception e)
            {
                return ExecutionResult.Fail(e);
            }
        }

        public async Task<ExecutionResult<CustomerDTO>> GetInfo(GetCustomerInfoViewModel model)
        {
            try
            {
                var query = new GetCustomerInfoQuery(model.CustomerId);
                return await _bus.Send(query, CancellationToken.None);
            }
            catch (Exception e)
            {
                return ExecutionResult<CustomerDTO>.Fail(e);
            }
        }
    }
}
