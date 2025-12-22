using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAssessment.WebMVC.Data;
using MyAssessment.WebMVC.Models;
using MyAssessment.WebMVC.Services;

namespace MyAssessment.WebMVC.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ICartService _cartService;
        private readonly ApplicationDbContext _context;
        public ShoppingCartController(ICartService cartService, ApplicationDbContext context)
        {
            _cartService = cartService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<CartItem> cartItems = _cartService.GetCart();
            return View(cartItems);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            _cartService.AddToCart(product);
            return RedirectToAction("index");
        }
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}