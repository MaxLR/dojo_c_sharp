// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;
namespace EntityFrameworkLectures.Models;

public class Post
{
    
    [Key] // Primary Key
    public int PostId { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
    [MaxLength(20, ErrorMessage = "must be less than 20 characters.")]
    public string Topic { get; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
    public string Body { get; set; }

    [Display(Name = "Image Url")]
    public string? ImgUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}