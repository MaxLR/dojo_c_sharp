#pragma warning disable CS8618
/* 
Disabled Warning: "Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable."
We can disable this safely because we know the framework will assign non-null values when it constructs this class for us.
*/
using Microsoft.EntityFrameworkCore;
namespace BeltReview.Models;
// the EntityFrameWorkLecturesContext class representing a session with our MySQL database, allowing us to query for or save data
public class BeltReviewContext : DbContext 
{ 
    public BeltReviewContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; } 
    public DbSet<Vacation> Vacations { get; set; } 
    public DbSet<UserVacationSignup> UserVacationSignups { get; set; } 
}