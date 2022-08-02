//need this line to be able to access classes from the People namespace (Person, Instructor, Student)
using People;

//declaring what namespace our Lecture class belongs to
namespace Places;

public class Lecture
{
    public Instructor CourseInstructor { get; set; }
    public List<Student> Roster { get; set; }
    public string Topic { get; set; }

    public Lecture(Instructor courseInstructor, List<Student> roster, string topic) {
        CourseInstructor = courseInstructor;
        Roster = roster;
        Topic = topic;
    }

    public void PrintAttendance()
    {
        foreach (Student student in Roster)
        {
            Console.WriteLine(student.FullName());
        }
    }
}