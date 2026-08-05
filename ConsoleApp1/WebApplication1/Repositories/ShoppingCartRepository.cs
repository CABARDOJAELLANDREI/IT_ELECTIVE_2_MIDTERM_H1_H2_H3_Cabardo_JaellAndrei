using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Repositories
{
    public class ShoppingCartRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
