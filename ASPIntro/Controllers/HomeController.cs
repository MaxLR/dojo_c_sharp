using ASPIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPIntro.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public string Index()
    {
        return "Hello C# Class!!";
    }

    [HttpGet("/second_route")]
    public ViewResult RouteTwo()
    {
        return View("Index");
    }

    [HttpGet("/videos")]
    public ViewResult Videos()
    {
        VideosView videoViewModel = new VideosView();
        return View("Videos", videoViewModel);
    }

    [HttpGet("{**path}")]
    public IActionResult UnkownRoute()
    {
        return RedirectToAction("RouteTwo");
    }
}