using OOPDemo;

Person lee = new Person("Lee", "Rios");
Student jason = new Student("Jason", "Frantz", "C#");
Student aparna = new Student("Aparna", "Hari", "C#");
Student austin = new Student("Austin", "Baumbach", "C#");
Student marcela = new Student("Marcela", "Romero", "C#");

List<Student> studentList = new List<Student>();
studentList.Add(jason);
studentList.Add(aparna);
studentList.Add(austin);
studentList.Add(marcela);

Lecture cSharpLecture = new Lecture("OOP", DateTime.Now, studentList);
cSharpLecture.PrintAttendance();

// Console.WriteLine(lee.FullName());
// Console.WriteLine(jason.FullName());
// Console.WriteLine(jason.CurrentStack);