using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models.Entities
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalAmount => Items.Sum(i => i.Subtotal);
    }
}