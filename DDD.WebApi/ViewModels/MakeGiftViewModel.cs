using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.WebApi.ViewModels
{
    public class MakeGiftViewModel
    {
        [Required]
        public Guid FromCustomerId { get; set; }
        
        [Required]
        public Guid ToCustomerId { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
    }
}