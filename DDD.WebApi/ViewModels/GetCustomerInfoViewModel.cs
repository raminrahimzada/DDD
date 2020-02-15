using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.WebApi.ViewModels
{
    public class GetCustomerInfoViewModel
    {

        [Required]
        public Guid CustomerId { get; set; }
    }
}