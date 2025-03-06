using Microsoft.AspNetCore.Mvc;

namespace LuxStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")] // Burası Admin alanına ait bir controller.
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
