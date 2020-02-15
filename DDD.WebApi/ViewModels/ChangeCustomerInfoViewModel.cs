using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.WebApi.ViewModels
{
    public class ChangeCustomerInfoViewModel
    {
        [Required]
        public string NewName { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
    }
}