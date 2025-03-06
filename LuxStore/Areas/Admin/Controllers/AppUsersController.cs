using LuxStore.Areas.Admin.Controllers;
using LuxStore.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuxStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUsersController : BaseController
    {
        private readonly AppDbContext _context;

        public AppUsersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AppUsers.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appUser);
                await _context.SaveChangesAsync();
                SetNotification("Kullanıcı başarıyla eklendi.", "success");
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id) // https://localhost:7033/Admin/AppUsers/Update/1 bu endpoint kullanıcı bir user için Update isteğinde bulunduğu zaman oluşur.
        {
            if (id == null)
            {
                return NotFound();
            }
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, AppUser appUser)
        {
            if (id != appUser.Id) //eğer gelen userId ile appUser'ın Id'si eşit değilse
            {
                return NotFound(); //404 hatası döndür.
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //herhangi bir sorun yoksa bu blok çalışacak
                    _context.Update(appUser);
                    await _context.SaveChangesAsync();
                    SetNotification("Kullanıcı başarıyla güncellendi.", "warning");
                }
                catch (DbUpdateConcurrencyException) //eğer hata varsa buraya düşecek.
                {
                    if (!_context.AppUsers.Any(a => a.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // throw ile hata fırlatıyoruz. Bu hata, uygulamamızın hata sayfasına düşecek.
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var appUser = await _context.AppUsers.FindAsync(id);
            var appUser = await _context.AppUsers.FirstOrDefaultAsync(a => a.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();
            SetNotification("Kullanıcı başarıyla silindi.", "danger");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var appUser = await _context.AppUsers.FindAsync(id);
            var appUser = await _context.AppUsers.FirstOrDefaultAsync(a => a.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }
    }
}