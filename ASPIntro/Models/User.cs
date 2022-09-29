// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName()
    {
        return FirstName + " " + LastName;
    }
}