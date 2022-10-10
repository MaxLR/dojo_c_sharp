// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped] // don't add table to db
public class LoginUser
{
    [Required(ErrorMessage = "is required")]
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string LoginEmail { get; set; }

    [Required(ErrorMessage = "is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LoginPassword { get; set; }
}