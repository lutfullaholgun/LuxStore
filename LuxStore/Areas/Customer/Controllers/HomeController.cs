using Microsoft.AspNetCore.Mvc;

namespace LuxStore.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
