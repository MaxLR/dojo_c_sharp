using ASPNetDemo.Models;
using Microsoft.AspNetCore.Mvc;

//Inherits from the abstract base controller class
//inherits helpful methods for handling HTTP req/response cycle

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("/videos")]
    public IActionResult Videos()
    {
        // Removing our list & title from ViewBag to now use ViewModel
        // List<string> youtubeVideoIds = new List<string>
        // {
        //     "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI"
        // };

        // ViewBag.YoutubeVideoIds = youtubeVideoIds;
        // ViewBag.Title = $"Here are {youtubeVideoIds.Count} of my favorite videos";

        VideosView videoObject = new VideosView();
        videoObject.Title = "Updated Title";

        return View("Videos", videoObject);
    }

    //new route to display our model using the ViewBag
    [HttpGet("/showingModel")]
    public IActionResult ModelDisplay() {
        List<int> myNums = new List<int>() { 1, 2, 3 };
        MyModel someModel = new MyModel("squirtle", myNums);

        ViewBag.MyModel = someModel;
        return View();
    }
}