using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuxStore.DataAccessLayer;
using LuxStore.EntityLayer.Entities;
using LuxStore.Helpers;

namespace LuxStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Books
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Books.Include(b => b.Author).Include(b => b.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Books books, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                books.Image = await FileHelper.FileUploader(Image, "/Images/books/");
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName", books.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", books.CategoryId);
            return View(books);
        }

        // GET: Admin/Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName", books.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", books.CategoryId);
            return View(books);
        }

        // POST: Admin/Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Books books)
        {
            if (id != books.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName", books.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", books.CategoryId);
            return View(books);
        }

        // GET: Admin/Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.Books.FindAsync(id);
            if (books != null)
            {
                _context.Books.Remove(books);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        // GET: Admin/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }
    }
}