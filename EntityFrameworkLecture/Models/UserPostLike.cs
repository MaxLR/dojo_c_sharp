// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkLecture.Models;

public class UserPostLike {  // Many to many "Through"/"Join" table
    [Key]
    public int UserPostLikeId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    /**********************************************************************
    Relationship properties below

    Foreign Keys: id of a different (foreign) model

    Navigation Props:
        data type is a related model
        MUST use the .Include for the nav prop data to be included via a SQL JOIN statement
    **********************************************************************/
    public int UserId { get; set; }
    public User? User { get; set; }
    public int PostId { get; set; }
    public Post? Post { get; set; }
}