using BeltReview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class VacationsController : Controller
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

    private BeltReviewContext db;
    public VacationsController(BeltReviewContext context)
    {
        db = context;
    }

    [HttpGet("/vacations/new")]
    public IActionResult New()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        return View("New");
    }

    [HttpPost("/vacations/create")]
    public IActionResult Create(Vacation newVacation)
    {
        if (!loggedIn || uid == null)
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

        // attaching currently logged in user's ID to the newVacation
        newVacation.UserId = (int)uid;

        Console.WriteLine(newVacation.VacationId);
        // ModelState IS valid
        db.Vacations.Add(newVacation);
        // db doesn't update until we run save changes
        // after SaveChanges, our newVacation object will have its VacationId updated from the db auto-generated id
        db.SaveChanges();
        Console.WriteLine(newVacation.VacationId);

        return RedirectToAction("All");

        /*
        The ORM .Add method generated a SQL insert mapping the new Vacation properties
        to their corresponding SQL columns, like so:

        INSERT INTO Vacations (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
        VALUES (newVacation.Topic, newVacation.Body, newVacation.ImgUrl, NOW(), NOW());
        */
    }

    [HttpGet("/vacations")]
    public IActionResult All()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        // get all Vacations, and include author info for each individual Vacation in addition to the foreign key
        List<Vacation> allVacations = db.Vacations
            // .Include always gives you the entity from the queried table, so both
            // .Include statements refer to Vacation
            .Include(v => v.Planner)
            .Include(v => v.VacationSignups)
            .ToList();
            // ^ what you would have to write in SQL
        // SELECT * FROM Vacations JOIN users on Vacation.UserId = user.UserId

        return View("All", allVacations);
    }

    [HttpGet("/vacations/{oneVacationId}")]
    public IActionResult GetOneVacation(int oneVacationId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Vacation? Vacation = db.Vacations
            .Include(v => v.Planner)
            .Include(v => v.VacationSignups)
            .ThenInclude(vs => vs.User)
            .FirstOrDefault(v => v.VacationId == oneVacationId);

        // In case user manually types in an invalid ID in the url
        if (Vacation == null)
        {
            return RedirectToAction("All");
        }

        return View("ViewOne", Vacation);
    }

    [HttpPost("/vacations/{deletedVacationId}/delete")]
    public IActionResult DeleteVacation(int deletedVacationId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Vacation? vacation = db.Vacations.FirstOrDefault(p => p.VacationId == deletedVacationId);

        if (vacation != null && vacation.UserId == uid)
        {
            db.Vacations.Remove(vacation);
            db.SaveChanges();
        }
        return RedirectToAction("All");
    }

    [HttpGet("/Vacations/{vacationId}/edit")]
    public IActionResult Edit(int vacationId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Vacation? vacation = db.Vacations.FirstOrDefault(p => p.VacationId == vacationId);

        if(vacation == null || vacation.UserId != uid)
        {
            return RedirectToAction("All");
        }

        return View("Edit", vacation);
    }

    [HttpPost("/vacations/{vacationId}/update")]
    public IActionResult Update(Vacation editedVacation, int vacationId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        if (ModelState.IsValid == false)
        {
            return Edit(vacationId);
        }

        Vacation? dbVacation = db.Vacations.FirstOrDefault(vacation => vacation.VacationId == vacationId);

        if (dbVacation == null || dbVacation.UserId != uid)
        {
            return RedirectToAction("All");
        }

        dbVacation.Destination = editedVacation.Destination;
        dbVacation.Details = editedVacation.Details;
        dbVacation.StartDate = editedVacation.StartDate;
        dbVacation.UpdatedAt = DateTime.Now;

        db.Vacations.Update(dbVacation);
        db.SaveChanges();

        // return Redirect($"/Vacations/{dbVacation.VacationId}");
        return RedirectToAction("GetOneVacation", new { VacationId = dbVacation.VacationId });
    }

    [HttpPost("/vacations/{vacationId}/signup")]
    public IActionResult Signup(int vacationId)
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "Users");
        }

        UserVacationSignup? existingSignup = db.UserVacationSignups
            .FirstOrDefault(l => l.VacationId == vacationId && l.UserId == (int)uid);

        if (existingSignup == null)
        {
            UserVacationSignup newSignup = new UserVacationSignup()
            {
                UserId = (int)uid,
                VacationId = vacationId
            };

            db.UserVacationSignups.Add(newSignup);
        }
        else
        {
            db.UserVacationSignups.Remove(existingSignup);
        }

        db.SaveChanges();
        return RedirectToAction("All");
    }
}