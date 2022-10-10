using BeltReview.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UsersController : Controller
{

    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    private BeltReviewContext db;
    public UsersController(BeltReviewContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        if(loggedIn)
        {
            return RedirectToAction("All", "Vacations");
        }
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (db.Users.Any(u => u.EmailAddress == newUser.EmailAddress))
            {
                ModelState.AddModelError("EmailAddress", "is taken");
            }
        }

        // in case any above custom errors were added
        if (ModelState.IsValid == false)
        {
            // return index function so that error messages will be displayed
            return Index();
        }

        //hash pw
        PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
        newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();

        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        return RedirectToAction("All", "Vacations");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            //display error messages
            return Index();
        }

        User? dbUser = db.Users.FirstOrDefault(u => u.EmailAddress == loginUser.LoginEmail);

        if (dbUser == null)
        {
            // Normally these kinds of errors should be vague to avoid phishing.
            // but we will keep them specific to help us test.
            // generic message example: "Username/Password don't match"
            ModelState.AddModelError("LoginUsername", "not found");
            return Index();
        }

        // if we get to this point, user exists, so we need to check password matching
        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hashBrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        // if PasswordVerificationResult == 0, passwords don't match
        if (pwCompareResult == 0)
        {
            // Normally these kinds of errors should be vague to avoid phishing.
            // but we will keep them specific to help us test.
            ModelState.AddModelError("LoginPassword", "invalid password");
            return Index();
        }

        // no returns happened, therefore no errors
        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        return RedirectToAction("All", "Vacations");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}