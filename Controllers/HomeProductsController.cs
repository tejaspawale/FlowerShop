using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAssessment.WebMVC.Data;
using MyAssessment.WebMVC.Models;
using System.Text.Json;


namespace MyAssessment.WebMVC.Controllers
{
    public class HomeProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Anniversary()
        {
            var products = await _context.HomeProducts
                .Where(p => p.Category == "Anniversary")
                .ToListAsync();

            return View("ProductList", products);
        }

        public async Task<IActionResult> Birthday()
        {
            var products = await _context.HomeProducts
                .Where(p => p.Category == "Birthday")
                .ToListAsync();

            return View("ProductList", products);
        }

        public async Task<IActionResult> GrandGestures()
        {
            var products = await _context.HomeProducts
                .Where(p => p.Category == "Grand Gestures")
                .ToListAsync();

            return View("ProductList", products);
        }

        [HttpPost]
        public IActionResult Like(int id)
        {
            var product = _context.HomeProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return Json(new { success = false });

            var data = HttpContext.Session.GetString("WISHLIST");
            List<int> wishlist = string.IsNullOrEmpty(data)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(data)!;

            if (!wishlist.Contains(id))
            {
                wishlist.Add(id);
                HttpContext.Session.SetString(
                    "WISHLIST",
                    JsonSerializer.Serialize(wishlist));
            }

                return Json(new { success = true });
        }
    }
}
