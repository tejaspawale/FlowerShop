using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAssessment.WebMVC.Data;
using MyAssessment.WebMVC.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyAssessment.WebMVC.Data;      // ✅ CORRECT
using MyAssessment.WebMVC.Models; 

namespace MyAssessment.WebMVC.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(Subscription model)
        {
            // Validate the form data
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            // Save to database
            _context.Subscriptions.Add(model);
            await _context.SaveChangesAsync();

            // Show success message
            TempData["SubscriptionSuccess"] = "Thanks! Check your email for 10% off coupon.";
            
            return RedirectToAction("Index", "Home");
        }
    }
}
