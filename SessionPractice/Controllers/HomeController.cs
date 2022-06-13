using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionPractice.Models;

namespace SessionPractice.Controllers;

public class HomeController : Controller
{

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/login")]
    public IActionResult Login(User newUser)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Username", newUser.Username);
            return RedirectToAction("StoryTime");
        }
        return View("Index");
    }

    [HttpGet("/story")]
    public IActionResult StoryTime()
    {
        string? story = HttpContext.Session.GetString("story");

        if (story == null)
        {
            HttpContext.Session.SetString("story", "");
        }

        return View("StoryTime");
    }

    [HttpPost("/story/add")]
    public IActionResult AddWord(StoryFragment newWord)
    {
        string updatedStory = HttpContext.Session.GetString("story");
        updatedStory += " " + newWord.Word;
        HttpContext.Session.SetString("story", updatedStory);
        return RedirectToAction("StoryTime");
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("Username");

        // This line clears EVERYTHING out of session.
        // HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }


}
