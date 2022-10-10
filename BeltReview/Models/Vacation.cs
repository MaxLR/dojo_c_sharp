// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;
namespace BeltReview.Models;

public class Vacation
{
    
    [Key] // Primary Key
    public int VacationId { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
    [MaxLength(20, ErrorMessage = "must be less than 20 characters.")]
    public string Destination { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
    public string Details { get; set; }

    [Display(Name = "Start Date")]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    /**********************************************************************
    Relationship properties below

    Foreign Keys: id of a different (foreign) model.

    Navigation props:
        data type is a related model
        MUST use .Include for the nav prop data to be included via a SQL JOIN.
    **********************************************************************/
    public int UserId { get; set; } // this foreign key MUST match primary property name
    public User? Planner { get; set; } // the ONE user related to each post

    // Many to Many - 1 post can be liked by many users
    public List<UserVacationSignup> VacationSignups { get; set; } = new List<UserVacationSignup>();

}