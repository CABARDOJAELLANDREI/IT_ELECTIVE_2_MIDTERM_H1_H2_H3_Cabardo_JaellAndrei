using System;
using System.Collections.Generic;

namespace WebApplication1.Models.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; } = Guid.NewGuid();
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalAmount { get; set; }
    }
}