using System.Linq;
using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories
{
    public static class ShoppingCartRepository
    {
        private static readonly ShoppingCart _cart = new ShoppingCart();

        public static ShoppingCart GetCart() => _cart;

        public static void AddItem(Product product, int quantity)
        {
            var existingItem = _cart.Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cart.Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = quantity
                });
            }
        }

        public static void UpdateQuantity(int productId, int quantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    _cart.Items.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
            }
        }

        public static void RemoveItem(int productId)
        {
            _cart.Items.RemoveAll(i => i.ProductId == productId);
        }

        public static void Clear()
        {
            _cart.Items.Clear();
        }
    }
}