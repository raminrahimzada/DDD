using System;
using System.Threading.Tasks;
using DDD.WebApi.Services;
using DDD.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route(nameof(Create))]
        [HttpGet]
        public async Task<IActionResult> Create([FromQuery]CreateCustomerViewModel model)
        {
            try
            {
                var result=await _customerService.CreateCustomer(model);
                return Json(result);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
        
        [Route(nameof(MakeGift))]
        [HttpGet]
        public async Task<IActionResult> MakeGift( Guid from, Guid to,decimal amount)
        {
            try
            {
                await _customerService.MakeGift(from, to, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
        
        [Route(nameof(ChangeInfo))]
        [HttpGet]
        public async Task<IActionResult> ChangeInfo([FromQuery]ChangeCustomerInfoViewModel model)
        {
            try
            {
                await _customerService.ChangeInfo(model);
                return Ok();
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        [Route(nameof(Info))]
        [HttpGet]
        public async Task<IActionResult> Info([FromQuery]GetCustomerInfoViewModel model)
        {
            try
            {
                var result = await _customerService.GetInfo(model);
                return Json(result);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        //helper
        private IActionResult Error(Exception e)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            return Json(new {ErrorCode = e.ToString(), Message = e.Message});
        }
    }
}