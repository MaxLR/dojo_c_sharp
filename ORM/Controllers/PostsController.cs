using Microsoft.AspNetCore.Mvc;
using ORM.Models;


public class PostsController : Controller
{
    private ORMContext _context;

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

    public PostsController(ORMContext context)
    {
        _context = context;
    }

    [HttpGet("/posts/new")]
    public IActionResult New()
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginReg", "Users");
        }
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

    [HttpGet("/posts/{postID}")]
    public IActionResult Details(int postID)
    {
        Post? post = _context.Posts.FirstOrDefault(post => post.PostId == postID);

        if (post == null)
        {
            return RedirectToAction("All");
        }

        return View(post);
    }

    [HttpPost("/posts/delete/{postId}")]
    public IActionResult Delete(int postId)
    {
        Post? post = _context.Posts.FirstOrDefault(post => post.PostId == postId);

        if (post != null)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        return RedirectToAction("All");
    }

    [HttpGet("/posts/{postId}/edit")]
    public IActionResult Edit(int postId)
    {
        Post? post = _context.Posts.FirstOrDefault(post => post.PostId == postId);

        if (post != null)
        {
            return View("Edit", post);
        }

        return RedirectToAction("All");
    }

    [HttpPost("/posts/{postId}/update")]
    public IActionResult Update(Post editedPost, int postId)
    {
        if (ModelState.IsValid)
        {
            Post? dbPost = _context.Posts.FirstOrDefault(post => post.PostId == postId);

            if (dbPost != null)
            {
                dbPost.Topic = editedPost.Topic;
                dbPost.Body = editedPost.Body;
                dbPost.ImgUrl = editedPost.ImgUrl;
                dbPost.UpdatedAt = DateTime.Now;

                _context.Posts.Update(dbPost);
                _context.SaveChanges();
            }

            return RedirectToAction("Details", postId);
        }
        else
        {
            return Edit(postId);
        }
    }
}