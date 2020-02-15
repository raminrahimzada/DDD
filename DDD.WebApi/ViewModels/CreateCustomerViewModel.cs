using System.ComponentModel.DataAnnotations;

namespace DDD.WebApi.ViewModels
{
    public class CreateCustomerViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
