// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Vacation
{
    [Key]
    public int VacationId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "is required.")]
    [MinLength(10, ErrorMessage = "must be at least 10 characters")]
    public string Description { get; set; }

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public string? ImgUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? Planner { get; set; }
}