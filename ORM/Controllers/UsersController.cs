using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORM.Models;

public class UsersController : Controller
{
    private ORMContext _context;


    public UsersController(ORMContext context)
    {
        _context = context;
    }


    [HttpGet("/registration")]
    public IActionResult LoginReg()
    {
        return View("LoginReg");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
            }
        }

        if (ModelState.IsValid == false)
        {
            return LoginReg();
        }

        PasswordHasher<User> HashBrowns = new PasswordHasher<User>();
        newUser.Password =HashBrowns.HashPassword(newUser, newUser.Password);

        _context.Users.Add(newUser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("UUID", newUser.UserId);

        return RedirectToAction("All", "Posts");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return LoginReg();
        }

        User? dbUser = _context.Users.FirstOrDefault(u => u.Email == loginUser.Email);

        if (dbUser == null)
        {
            ModelState.AddModelError("Email", "and Password don't match");
            return LoginReg();
        }

        PasswordHasher<LoginUser> HashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompare = HashBrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.Password);

        if (pwCompare == 0)
        {
            ModelState.AddModelError("Password", "doesn't match this email");
            return LoginReg();
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        return RedirectToAction("All", "Posts");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LoginReg");
    }
}