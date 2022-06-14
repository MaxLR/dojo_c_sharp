#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;

public class Post
{
    [Key]
    public int PostId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
    [MaxLength(40, ErrorMessage = "must be less than 40 characters.")]
    public string Topic { get; set; }

    [Required]
    [MinLength(2, ErrorMessage ="must be more than 2 characters.")]
    public string Body { get; set; }

    // since this is optional, we don't want to use the [Required] tag helper
    [Display(Name = "Image URL")]
    public string? ImgUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}