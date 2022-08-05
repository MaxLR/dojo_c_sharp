using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionAndValidations.Models;

namespace SessionAndValidations.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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
    public IActionResult AddToStory(StoryFragment newStoryFragment)
    {
        string? updatedStory = HttpContext.Session.GetString("story");

        if (updatedStory == null)
        {
            updatedStory = newStoryFragment.Word;
        }
        else
        {
            updatedStory += " " + newStoryFragment.Word;
        }

        HttpContext.Session.SetString("story", updatedStory);
        return RedirectToAction("StoryTime");
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
