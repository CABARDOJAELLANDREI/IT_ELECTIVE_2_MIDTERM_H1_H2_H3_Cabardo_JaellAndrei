using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories
{
    public static class ProductRepository
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "The Amazing Spider-Man #300", Price = 25.00m, StockQuantity = 5 },
            new Product { Id = 2, Name = "Batman: The Dark Knight Returns", Price = 19.99m, StockQuantity = 3 },
            new Product { Id = 3, Name = "Watchmen Deluxe Edition", Price = 35.00m, StockQuantity = 8 },
            new Product { Id = 4, Name = "X-Men #1 (1991)", Price = 12.50m, StockQuantity = 0 },
            new Product { Id = 5, Name = "Saga Volume 1", Price = 9.99m, StockQuantity = 10 },
            new Product { Id = 6, Name = "Kingdom Come Hardcover", Price = 29.99m, StockQuantity = 2 }
        };

        public static List<Product> GetAll() => _products;

        public static Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}