#pragma warning disable CS8618 //disables warning for strings being non-nullable

namespace ASPIntro.Models;

public class User
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string FullName()
    {
        return FirstName + " " + LastName;
    }
}