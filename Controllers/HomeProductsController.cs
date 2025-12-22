using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAssessment.WebMVC.Data;
using MyAssessment.WebMVC.Models;

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
    }
}
