using System.ComponentModel.DataAnnotations;

namespace VacationPlanner.Models;

public class UserVacationSignup
{
    [Key]
    public int UserVacationSignupId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? Vacationer { get; set; }

    public int VacationId { get; set; }
    public Vacation? Vacation { get; set; }
}