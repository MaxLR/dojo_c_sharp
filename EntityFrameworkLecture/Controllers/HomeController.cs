using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkLecture.Models;

namespace EntityFrameworkLecture.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
