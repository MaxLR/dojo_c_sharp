public class Lecture
{
    public string Topic { get; set; }
    public DateTime StartDate { get; set; }
    public Person Teacher { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    public Lecture(string topic, DateTime startDate, Person teacher, List<Student> students)
    {
        Topic = topic;
        StartDate = startDate;
        Teacher = teacher;
        Students = students;
    }

    public void PrintAttendanceList()
    {
        string attendingStudents = "";

        foreach (Student student in Students)
        {
            attendingStudents += student.FullName() + "\n";
        }

        Console.WriteLine(attendingStudents);
    }
}