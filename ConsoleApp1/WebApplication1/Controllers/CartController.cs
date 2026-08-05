using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var cart = ShoppingCartRepository.GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(AddToCartDTO dto)
        {
            var product = ProductRepository.GetById(dto.ProductId);
            if (product == null)
            {
                TempData["Error"] = "Product not found.";
                return RedirectToAction("Index", "Product");
            }

            if (dto.Quantity > product.StockQuantity)
            {
                TempData["Error"] = $"Cannot add {dto.Quantity} units. Only {product.StockQuantity} available.";
                return RedirectToAction("Index", "Product");
            }

            ShoppingCartRepository.AddItem(product, dto.Quantity);
            TempData["Success"] = $"Added {product.Name} to cart!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(UpdateCartDTO dto)
        {
            var product = ProductRepository.GetById(dto.ProductId);
            if (product != null && dto.Quantity > product.StockQuantity)
            {
                TempData["Error"] = $"Cannot request {dto.Quantity}. Maximum available stock is {product.StockQuantity}.";
                return RedirectToAction("Index");
            }

            ShoppingCartRepository.UpdateQuantity(dto.ProductId, dto.Quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveItem(int productId)
        {
            ShoppingCartRepository.RemoveItem(productId);
            return RedirectToAction("Index");
        }
    }
}