using LuxStore.DataAccessLayer;
using LuxStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eBookApp.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _appDbContext.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}