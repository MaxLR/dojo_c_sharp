using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    // attribute, http type & the route URL
    [HttpGet("/register")]
    public ViewResult Register()
    {
        // respond to request
        return View("Register");
    }

    [HttpPost("/submit-user")]
    public ViewResult SubmitUser(User newUser)
    {
        // respond to request
        return View("Success", newUser);
    }
}