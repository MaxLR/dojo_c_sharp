using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPDemo;
public class Lecture
{
    public string Topic { get; set; }
    public DateTime StartDate { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    public Lecture(string topic, DateTime startDate, List<Student> students)
    {
        Topic = topic;
        StartDate = startDate;
        Students = students;
    }

    public void PrintAttendance()
    {
        foreach (Student student in Students)
        {
            Console.WriteLine(student.FullName());
        }
    }
}
