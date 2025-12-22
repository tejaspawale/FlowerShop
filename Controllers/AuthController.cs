using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyAssessment.WebMVC.Models;

namespace MyAssessment.WebMVC.Controllers;

public class AuthController : Controller
{
   // private readonly ILogger<HomeController> _logger;

    public AuthController()
    {
    }

    public IActionResult Signup()
    {
        return View();
    }
    public IActionResult SignIn()
    {
        return View();
    }


}