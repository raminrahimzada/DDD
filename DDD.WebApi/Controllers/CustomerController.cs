using System;
using System.Threading.Tasks;
using DDD.WebApi.ServiceFacades;
using DDD.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DDD.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerServiceFacade _customerServiceFacade;

        public CustomerController(CustomerServiceFacade customerServiceFacade)
        {
            _customerServiceFacade = customerServiceFacade;
        }

        [Route(nameof(Create))]
        [HttpGet]
        public async Task<IActionResult> Create([FromQuery]CreateCustomerViewModel model)
        {
            var result=await _customerServiceFacade.CreateCustomer(model);
            return Json(result);
        }
        
        [Route(nameof(MakeGift))]
        [HttpGet]
        public async Task<IActionResult> MakeGift( Guid from, Guid to,decimal amount)
        {
            var result = await _customerServiceFacade.MakeGift(from, to, amount);
            return Json(result);
        }

        [Route(nameof(ChangeInfo))]
        [HttpGet]
        public async Task<IActionResult> ChangeInfo([FromQuery] ChangeCustomerInfoViewModel model)
        {
            var result = await _customerServiceFacade.ChangeInfo(model);
            return Json(result);
        }

        [Route(nameof(Info))]
        [HttpGet]
        public async Task<IActionResult> Info([FromQuery] GetCustomerInfoViewModel model)
        {
            var result = await _customerServiceFacade.GetInfo(model);
            return Json(result);
        }
    }
}