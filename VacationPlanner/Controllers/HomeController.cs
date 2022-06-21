using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VacationPlanner.Models;

namespace VacationPlanner.Controllers;

public class HomeController : Controller
{
    private VacationsContext _context;

    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }

    public HomeController(VacationsContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        if(uid != null)
        {
            return RedirectToAction("AllVacations", "Vacations");
        }
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid == false)
        {
            return Index();
        }

        if (_context.Users.Any(user => user.Email == newUser.Email))
        {
            ModelState.AddModelError("Email", "is taken");
            return Index();
        }

        PasswordHasher<User> HashBrowns = new PasswordHasher<User>();
        newUser.Password = HashBrowns.HashPassword(newUser, newUser.Password);

        _context.Users.Add(newUser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("UserId", newUser.UserId);

        return RedirectToAction("AllVacations", "Vacations");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return Index();
        }

        User? dbUser = _context.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "and Password don't match");
            return Index();
        }

        PasswordHasher<LoginUser> HashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompare = HashBrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if (pwCompare == 0)
        {
            ModelState.AddModelError("LoginEmail", "and Password don't match");
            return Index();
        }

        HttpContext.Session.SetInt32("UserId", dbUser.UserId);
        return RedirectToAction("AllVacations", "Vacations");
    }

    [HttpGet("/success")]
    public IActionResult Success()
    {
        return View("Success");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
