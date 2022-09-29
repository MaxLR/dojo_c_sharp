using ASPIntro.Models;
using Microsoft.AspNetCore.Mvc;


// Inherit from an abstract base controller so our controller inherits
// helpful methods for handling HTTP req/res cycle
public class HomeController : Controller
{
    // attribute, http type & the route URL
    [HttpGet("")]
    public ViewResult Index()
    {
        // respond to request
        return View("Index");
    }

    [HttpGet("/videos")]
    // IActionResult can return a view or a redirect
    // easiest to default to IActionResult
    public IActionResult Videos()
    {
        // These ids are from the end of youtube video URLs (was moved to VideosView Model)
        // List<string> youtubeVideoIds = new List<string>
        // {
        // "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI"
        // };

        VideosView videoViewModel = new VideosView();

        /*
        Each controller method / 'action' has it's own ViewBag that is
        SEPARATE, the data is not shared between them.

        The ViewBag properties are automatically available in the View
        that is returned from this method.
        */

        // ViewBag.Title = $"Here are {youtubeVideoIds.Count} of my favorite Videos";

        return View("Videos", videoViewModel);
    }

    [HttpGet("{**path}")]
    public IActionResult CatchAll()
    {
        // return Redirect("/");
        return RedirectToAction("Index");
    }
}