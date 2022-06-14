using Microsoft.AspNetCore.Mvc;
using ORM.Models;

public class PostsController : Controller
{
    private ORMContext _context;

    public PostsController(ORMContext context)
    {
        _context = context;
    }

    [HttpGet("/posts/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("/posts/create")]
    public IActionResult Create(Post newPost)
    {
        if (ModelState.IsValid == false)
        {
            // if we don't validate, we'll send the user back to the create new post page
            return New();
        }

        //only runs if ModelState  *IS*  valid
        _context.Posts.Add(newPost);
        // _context doesn't update until we run SaveChanges
        // after SaveChanges, then our newPost will have a PostId
        _context.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpGet("/posts/all")]
    public IActionResult All()
    {
        List<Post> allPosts = _context.Posts.ToList();

        return View("All", allPosts);
    }
}