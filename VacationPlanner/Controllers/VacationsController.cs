using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationPlanner.Models;

namespace VacationPlanner.Controllers;

public class VacationsController : Controller
{
    private VacationsContext _context;

    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    public VacationsController(VacationsContext context)
    {
        _context = context;
    }

    [HttpGet("/vacations/new")]
    public IActionResult New()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "Home");
        }

        return View("New");
    }

    [HttpPost("/vacations/create")]
    public IActionResult Create(Vacation newVacation)
    {
        if (uid == null)
        {
            return RedirectToAction("Index", "Home");
        }

        //validating that the date of the vacation is in the future
        if (newVacation.Date < DateTime.Now)
        {
            ModelState.AddModelError("Date", "must be in the future.");
        }

        if (ModelState.IsValid == false)
        {
            return New();
        }

        //assigning the new vacation's UserId to the currently logged in user
        newVacation.UserId = (int)uid;

        _context.Vacations.Add(newVacation);
        _context.SaveChanges();

        return RedirectToAction("AllVacations");
    }

    [HttpGet("/vacations")]
    public IActionResult AllVacations()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "Home");
        }

        List<Vacation> vacations = _context.Vacations.Include(v => v.Planner).Include(v => v.JoinedVisitors).Where(v => v.Date > DateTime.Now).ToList();

        return View("AllVacations", vacations);
    }

    [HttpGet("/vacations/{vacationId}")]
    public IActionResult ViewOne(int vacationId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "Home");
        }
        Vacation? vacation = _context.Vacations.Include(v => v.Planner).Include(v => v.JoinedVisitors).ThenInclude(vacationer => vacationer.Vacationer).FirstOrDefault(v => v.VacationId == vacationId);

        if(vacation == null)
        {
            return RedirectToAction("AllVacations");
        }

        return View("ViewOne", vacation);
    }

    [HttpPost("/vacations/{vacationId}/join")]
    public IActionResult JoinVacation(int vacationId)
    {
        if (uid == null)
        {
            return RedirectToAction("Index", "Home");
        }

        UserVacationSignup? existingRegistration = _context.UserVacationSignups.FirstOrDefault(s => s.UserId == uid && s.VacationId == vacationId);

        if (existingRegistration == null)
        {
            UserVacationSignup newSignup = new UserVacationSignup()
            {
                VacationId = vacationId,
                UserId = (int)uid
            };

            _context.UserVacationSignups.Add(newSignup);
        }
        else
        {
            _context.UserVacationSignups.Remove(existingRegistration);
        }

        _context.SaveChanges();
        return RedirectToAction("Vacations");
    }
}