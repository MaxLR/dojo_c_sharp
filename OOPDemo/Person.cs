//updated namespace for mini-lecture
namespace People;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;
        Console.WriteLine("Hello from parent");
    }

    public string FullName() {
        return $"{FirstName} {LastName}";
    }
}
