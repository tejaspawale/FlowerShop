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


    [HttpPost]
    public async Task<IActionResult> AddToCart(int id, int qty = 1)
    {
    var hp = await _context.HomeProducts.FirstOrDefaultAsync(p => p.Id == id);
    if (hp == null) return NotFound();

    var product = new Product
    {
        Id        = hp.Id,
        Name      = hp.Name,
        Des       = hp.Des,
        UnitPrice = hp.UnitPrice,
        Quantity  = hp.Quantity,
        Likes     = hp.Likes,
        ImgUrl    = hp.ImgUrl
    };
    _cartService.AddToCart(product, qty);
    return RedirectToAction("Index");
    }

    [HttpPost]
public async Task<IActionResult> BuyNow(int id, int qty = 1)
{
    var hp = await _context.HomeProducts.FirstOrDefaultAsync(p => p.Id == id);
    if (hp == null) return NotFound();

    var product = new Product
    {
        Id        = hp.Id,
        Name      = hp.Name,
        Des       = hp.Des,
        UnitPrice = hp.UnitPrice,
        Quantity  = hp.Quantity,
        Likes     = hp.Likes,
        ImgUrl    = hp.ImgUrl
    };

    _cartService.AddToCart(product, qty);
    return RedirectToAction("Index");   // cart page
}



        
    }
}