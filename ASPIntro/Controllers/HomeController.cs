using Microsoft.AspNetCore.Mvc;

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
}