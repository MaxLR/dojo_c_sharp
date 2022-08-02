namespace OOPDemo;

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