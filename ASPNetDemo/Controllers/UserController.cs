using ASPNetDemo.Models;
using Microsoft.AspNetCore.Mvc;


public class UserController : Controller
{
    [HttpGet("/users/register")]
    public IActionResult Register()
    {
        return View("Register");
    }

    [HttpPost("/users/process-registration")]
    public IActionResult ProcessRegistration(User newUser)
    {
        return View("LoggedIn", newUser);
    }
}