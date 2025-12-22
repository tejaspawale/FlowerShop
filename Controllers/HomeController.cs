using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyAssessment.WebMVC.Models;
using Microsoft.EntityFrameworkCore;
using MyAssessment.WebMVC.Data;
using System.Threading.Tasks;

namespace MyAssessment.WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context; 
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new HomeBannerViewModel
            {
                Items = new List<HomeBannerItem>
                {
                    new HomeBannerItem
                    {
                        Title = "ANNIVERSARY",
                        ImageUrl = "/images/anniversary.jpg",
                        Controller = "HomeProducts",
                        Action = "Anniversary" // you will create these actions later
                    },
                    new HomeBannerItem
                    {
                        Title = "BIRTHDAY",
                        ImageUrl = "/images/birthday.jpg",
                        Controller = "HomeProducts",
                        Action = "Birthday"
                    },
                    new HomeBannerItem
                    {
                        Title = "GRAND GESTURES",
                        ImageUrl = "/images/grandgestures.jpg",
                        Controller = "HomeProducts",
                        Action = "GrandGestures"
                    }
                }
            };

            return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public async Task<IActionResult> Profile()
    {
        return View(await _context.Products.ToListAsync());
    }
    public async Task<IActionResult> Products()
    {
        var products = await _context.Products.ToListAsync();
        return View(products);
        //return View();
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
