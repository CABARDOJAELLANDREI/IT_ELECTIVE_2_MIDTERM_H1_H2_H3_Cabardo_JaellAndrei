using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class CheckoutFormDTO
    {
        [Required(ErrorMessage = "Customer name is required.")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Customer email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string CustomerEmail { get; set; } = string.Empty;
    }
}