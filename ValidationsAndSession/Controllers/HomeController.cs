using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ValidationsAndSession.Models;

namespace ValidationsAndSession.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Username", newUser.Username);
            return Redirect("/storytime");
        }

        return Index();
    }

    [HttpGet("/storytime")]
    public IActionResult StoryTime()
    {
        if (HttpContext.Session.GetString("Username") == null) {
            return Redirect("/");
        }

        string? story = HttpContext.Session.GetString("story");

        if (story == null)
        {
            // No story in session yet, set it to empty string
            // so that it's ready to concat to
            HttpContext.Session.SetString("story", "");
        }

        return View("StoryTime");
    }

    [HttpPost("/storytime/add")]
    public IActionResult AddToStory(StoryFragment storyFragment)
    {
        string? updatedStory = HttpContext.Session.GetString("story");

        if (updatedStory == null)
        {
            updatedStory = storyFragment.Word;
        }
        else
        {
            updatedStory += " " + storyFragment.Word;
        }

        HttpContext.Session.SetString("story", updatedStory);
        // redirecttoaction performs a redirect, but you can ALSO pass in objects to that method
        // return RedirectToAction("StoryTime");
        return Redirect("/storytime");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Username");
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
