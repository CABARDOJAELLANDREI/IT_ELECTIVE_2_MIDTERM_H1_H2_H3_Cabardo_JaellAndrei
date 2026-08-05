using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM.Models.DTOs
{
    public class AddToCartDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; } = 1;
    }
}