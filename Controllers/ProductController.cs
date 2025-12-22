using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAssessment.WebMVC.Data;
using MyAssessment.WebMVC.Models;

namespace MyAssessment.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Product
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // GET: /Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Des,ImgUrl,UnitPrice,Likes,Quantity")] Product prod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", "Home");
            }
            return View(prod);
        }

        // GET: /Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var prod = await _context.Products.FindAsync(id);
            if (prod == null) return NotFound();

            return View(prod);
        }

        // POST: /Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Des,ImgUrl,UnitPrice,Likes,Quantity")] Product prod)
        {
            if (id != prod.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Products.Any(e => e.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction("Profile", "Home");
            }
            return View(prod);
        }

        // GET: /Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (prod == null) return NotFound();

            return View(prod);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod != null)
            {
                _context.Products.Remove(prod);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Profile", "Home");
        }
    }
}
