using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Repositories
{
    public class ProductRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
