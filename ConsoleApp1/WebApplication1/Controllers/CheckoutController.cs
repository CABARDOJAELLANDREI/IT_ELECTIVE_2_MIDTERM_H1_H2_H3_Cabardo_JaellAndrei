using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var cart = ShoppingCartRepository.GetCart();
            if (!cart.Items.Any())
            {
                TempData["Error"] = "Your cart is empty. Please add items before checking out.";
                return RedirectToAction("Index", "Cart");
            }

            ViewBag.Cart = cart;
            return View(new CheckoutFormDTO());
        }

        [HttpPost]
        public IActionResult ProcessCheckout(CheckoutFormDTO dto)
        {
            var cart = ShoppingCartRepository.GetCart();
            if (!cart.Items.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Cart = cart;
                return View("Index", dto);
            }

            // Verify stock levels before proceeding
            foreach (var item in cart.Items)
            {
                var product = ProductRepository.GetById(item.ProductId);
                if (product == null || product.StockQuantity < item.Quantity)
                {
                    TempData["Error"] = $"Insufficient stock for {item.ProductName}. Check catalog limits.";
                    return RedirectToAction("Index", "Cart");
                }
            }

            // Deduct stock levels
            foreach (var item in cart.Items)
            {
                var product = ProductRepository.GetById(item.ProductId);
                if (product != null)
                {
                    product.StockQuantity -= item.Quantity;
                }
            }

            // Generate sale record
            var transaction = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                TransactionDate = DateTime.Now,
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                Items = new List<CartItem>(cart.Items),
                TotalAmount = cart.TotalAmount
            };

            TransactionRepository.Add(transaction);
            ShoppingCartRepository.Clear();

            return RedirectToAction("Success", new { id = transaction.TransactionId });
        }

        [HttpGet]
        public IActionResult Success(Guid id)
        {
            var transaction = TransactionRepository.GetById(id);
            if (transaction == null)
            {
                return RedirectToAction("Index", "Product");
            }
            return View(transaction);
        }

        [HttpGet]
        public IActionResult History()
        {
            var transactions = TransactionRepository.GetAll();
            return View(transactions);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var transaction = TransactionRepository.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }
    }
}