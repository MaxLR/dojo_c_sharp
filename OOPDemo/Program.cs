using OOPDemo;

// Person cody = new Person("Cody", "Adams");
Student studiousCody = new Student("Cody", "Adams", 13);
Student studiousAlex = new Student("Alex", "Miller", 1);
Student yukio = new Student("Yukio", "Rideb", 29);

List<string> taughtCourses = new List<string>();

List<Student> studentList = new List<Student>() {
    studiousAlex,
    studiousCody,
    yukio
};

taughtCourses.Add("Python");
taughtCourses.Add("C#");
taughtCourses.Add("MERN");
Instructor max = new Instructor("Max", "Rauchman", taughtCourses);

Lecture cSharp = new Lecture(max, studentList, "C#");

// Console.WriteLine(cody.FullName());
// Console.WriteLine(max.FullName());
// max.PrintCourses();
// Console.WriteLine(studiousAlex.FullName());
// Console.WriteLine(studiousAlex.StudentId);

Console.WriteLine(yukio.SecretNumber);


cSharp.PrintAttendance();