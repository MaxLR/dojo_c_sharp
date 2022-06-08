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

    [HttpGet("/videos")]
    public ViewResult Videos()
    {
        List<string> youtubeVideoIds = new List<string>()
        {
            "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI", "i_HaMlLJ7Jk"
        };

        ViewBag.YoutubeVideoIds = youtubeVideoIds;
        ViewBag.Title = $"Here are {ViewBag.YoutubeVideoIds.Count} of my favorite videos!";

        return View("Videos");
    }

    [HttpGet("{**path}")]
    public IActionResult UnkownRoute()
    {
        return RedirectToAction("RouteTwo");
    }
}