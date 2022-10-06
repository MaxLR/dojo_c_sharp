using EntityFrameworkLectures.Models;
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

    private ForumContext db;
    public UsersController(ForumContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (db.Users.Any(u => u.Username == newUser.Username))
            {
                ModelState.AddModelError("Username", "is taken");
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
        HttpContext.Session.SetString("Username", newUser.Username);
        return RedirectToAction("All", "Posts");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            //display error messages
            return Index();
        }

        User? dbUser = db.Users.FirstOrDefault(u => u.Username == loginUser.LoginUsername);

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
        HttpContext.Session.SetString("Username", dbUser.Username);
        return RedirectToAction("All", "Posts");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    //if you want to view a profile for ANY user instead of currently logged in
    // pass userID through route url & method parameter & then into LINQ query
    [HttpGet("/profile")]
    public IActionResult Profile()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index");
        }

        User? dbUser = db.Users.Include(u => u.UserPosts).FirstOrDefault(u => u.UserId == uid);

        if (dbUser == null)
        {
            return RedirectToAction("Index");
        }

        return View("Profile", dbUser);
    }
}