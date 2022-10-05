using EntityFrameworkLectures.Models;
using Microsoft.AspNetCore.Mvc;

public class PostsController : Controller
{
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

    private ForumContext db;
    public PostsController(ForumContext context)
    {
        db = context;
    }

    [HttpGet("/posts/new")]
    public IActionResult New()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        return View("New");
    }

    [HttpPost("/posts/create")]
    public IActionResult Create(Post newPost)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        if (!ModelState.IsValid)
        {
            // send back to the page w/ the form so error messages are displayed
            // can call the New() function because we didn't default the returned view within it
            // allows that method to run w/o creating a new request response cycle (so we keep our errors)
            return New();
        }
        Console.WriteLine(newPost.PostId);
        // ModelState IS valid
        db.Posts.Add(newPost);
        // db doesn't update until we run save changes
        // after SaveChanges, our newPost object will have its PostId updated from the db auto-generated id
        db.SaveChanges();
        Console.WriteLine(newPost.PostId);

        return RedirectToAction("All");

        /*
        The ORM .Add method generated a SQL insert mapping the new post properties
        to their corresponding SQL columns, like so:

        INSERT INTO posts (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
        VALUES (newPost.Topic, newPost.Body, newPost.ImgUrl, NOW(), NOW());
        */
    }

    [HttpGet("/posts")]
    public IActionResult All()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        List<Post> allPosts = db.Posts.ToList();

        return View("All", allPosts);
    }

    [HttpGet("/posts/{onePostId}")]
    public IActionResult GetOnePost(int onePostId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Post? post = db.Posts.FirstOrDefault(p => p.PostId == onePostId);

        // In case user manually types in an invalid ID in the url
        if (post == null)
        {
            return RedirectToAction("All");
        }

        return View("Details", post);
    }

    [HttpPost("/posts/{deletedPostId}/delete")]
    public IActionResult DeletePost(int deletedPostId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Post? post = db.Posts.FirstOrDefault(p => p.PostId == deletedPostId);

        if (post != null)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }
        return RedirectToAction("All");
    }

    [HttpGet("/posts/{postId}/edit")]
    public IActionResult Edit(int postId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Post? post = db.Posts.FirstOrDefault(p => p.PostId == postId);

        if(post == null)
        {
            return RedirectToAction("All");
        }
        return View("Edit", post);
    }

    [HttpPost("/posts/{postId}/update")]
    public IActionResult Update(Post editedPost, int postId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        if (ModelState.IsValid == false)
        {
            return Edit(postId);
        }

        Post? dbPost = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if (dbPost == null)
        {
            return RedirectToAction("All");
        }

        dbPost.Topic = editedPost.Topic;
        dbPost.Body = editedPost.Body;
        dbPost.ImgUrl = editedPost.ImgUrl;
        dbPost.UpdatedAt = DateTime.Now;

        db.Posts.Update(dbPost);
        db.SaveChanges();

        // return Redirect($"/posts/{dbPost.PostId}");
        return RedirectToAction("GetOnePost", new { postId = dbPost.PostId });
    }
}