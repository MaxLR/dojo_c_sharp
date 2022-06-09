using ASPIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPIntro.Controllers;

public class UserController : Controller
{
    [HttpGet("/users/register")]
    public IActionResult Register()
    {
        return View("Register");
    }

    [HttpPost("/users/submit")]
    public IActionResult SubmitRegistration(User user)
    {
        return View("Login", user);
    }
}