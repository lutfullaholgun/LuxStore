using LuxStore.Areas.Admin.Controllers;
using LuxStore.DataAccessLayer;
using LuxStore.EntityLayer.Entities;
using LuxStore.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eBookApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : BaseController
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Categories/Creat
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                category.Image = await FileHelper.FileUploader(Image, "/Images/categories/");
                await _context.AddAsync(category);
                await _context.SaveChangesAsync();
                SetNotification("Kategori başarıyla eklendi.", "success");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(category);
        }

        // POST: Admin/Categories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Category category, IFormFile? Image, bool DeleteImg = false)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (DeleteImg)
                    {
                        category.Image = string.Empty;
                    }
                    if (Image is not null)
                        category.Image = await FileHelper.FileUploader(Image, "/Images/categories/");
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    SetNotification("Kategori başarıyla güncellendi.", "warning");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                if (!string.IsNullOrEmpty(category.Image))
                {
                    FileHelper.FileDeleter(category.Image, "/Images/categories/");
                }
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            SetNotification("Kategori başarıyla silindi.", "danger");
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}