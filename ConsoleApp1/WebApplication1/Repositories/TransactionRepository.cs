using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Repositories
{
    public class TransactionRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
