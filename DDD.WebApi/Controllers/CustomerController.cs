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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCustomerViewModel model)
        {
            var result=await _customerServiceFacade.CreateCustomer(model);
            return Json(result);
        }
        
        [Route(nameof(MakeGift))]
        [HttpPost]
        public async Task<IActionResult> MakeGift([FromBody] MakeGiftViewModel model)
        {
            var result = await _customerServiceFacade.MakeGift(model);
            return Json(result);
        }

        [Route(nameof(ChangeInfo))]
        [HttpPost]
        public async Task<IActionResult> ChangeInfo([FromBody] ChangeCustomerInfoViewModel model)
        {
            var result = await _customerServiceFacade.ChangeInfo(model);
            return Json(result);
        }

        [Route(nameof(Info))]
        [HttpPost]
        public async Task<IActionResult> Info([FromBody] GetCustomerInfoViewModel model)
        {
            var result = await _customerServiceFacade.GetInfo(model);
            return Json(result);
        }
    }
}