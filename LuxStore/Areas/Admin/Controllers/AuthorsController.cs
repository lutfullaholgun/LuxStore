using LuxStore.Helpers;
using LuxStore.Areas.Admin.Controllers;
using LuxStore.DataAccessLayer;
using LuxStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorsController : BaseController
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Authors
        public async Task<IActionResult> Index()
        {
            //var authors = await _context.Authors.ToListAsync();
            return View(await _context.Authors.ToListAsync());
        }

        // GET: Admin/Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author, IFormFile? Img)
        {
            if (ModelState.IsValid)
            {
                author.Img = await FileHelper.FileUploader(Img);
                _context.Add(author);
                await _context.SaveChangesAsync();
                SetNotification("Yazar başarıyla eklendi.", "success");
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Admin/Authors/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Admin/Authors/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Author author, IFormFile? Img, bool DeleteImg = false)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (DeleteImg)
                    {
                        author.Img = string.Empty;
                    }
                    if (Img is not null)
                        author.Img = await FileHelper.FileUploader(Img);

                    _context.Update(author);
                    SetNotification("Yazar başarıyla güncellendi.", "warning");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
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
            return View(author);
        }

        // GET: Admin/Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Admin/Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                if (!string.IsNullOrEmpty(author.Img))
                {
                    FileHelper.FileDeleter(author.Img);
                }
                _context.Authors.Remove(author);
            }
            SetNotification("Yazar başarıyla silindi.", "danger");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }

        // GET: Admin/Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
    }
}