// public class MyClass : InheritFromParentName is how you do inheritance in c#
public class Student : Person
{
    public string FavoriteLanguage { get; set; }

    // base calls the parent constructor that we inherit from
    public Student(string firstName, string lastName, string favoriteLanguage) : base(firstName, lastName)
    {
        FavoriteLanguage = favoriteLanguage;
    }

}