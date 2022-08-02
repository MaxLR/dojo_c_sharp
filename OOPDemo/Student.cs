//updated namespace
namespace People;

public class Student : Person
{
    //private fields cant' be accessed from outside the class
    private int _secretNumber = 5;

    //this is the default constructor to create the private field & public property
    public int StudentId { get; set; }

    //custom public getter to retrieve private field _secretNumber
    public int SecretNumber { get {
        return _secretNumber;
    }}

    //class constructor
    public Student(string firstName, string lastName, int studentId) : base(firstName, lastName) {
        StudentId = studentId;
        Console.WriteLine("Hello from child");
    }
}