using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models.DTOs
{
    public class CheckoutFormDTO : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
