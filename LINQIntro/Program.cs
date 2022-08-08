List<int> numbers = new List<int>(){ 1, 3, 6, 12345, 32, 11, 400, 9001, 7};

List<int> numsAboveTen = numbers.Where(num => num > 10).ToList();

List<int> numsBelowTen = numbers.Where(num => num < 10).ToList();

List<int> topThree = numbers.Where(num => num > 0 && num < 4).ToList();

// when running a .First(), if the value doesn't exist, we receive an error
// int missingBigNumber = numbers.First(num => num > 100000);

// when an int doesn't exist in list, firstordefault will return 0
int validMissingNumber = numbers.FirstOrDefault(num => num > 100000);

// Console.WriteLine(validMissingNumber);

// foreach (int num in numsAboveTen)
// {
//     Console.WriteLine(num);
// }

// foreach (int num in topThree)
// {
//     Console.WriteLine(num);
// }

// Console.WriteLine(firstNumAboveTen);

List<string> names = new List<string>(){
    "Adam",
    "Amanda",
    "spensir",
    "Juan",
    "Froilan",
    "Tre",
    "Alex Miller"
};


Person adam = new Person("Adam", "Bates", 117);
Person juan = new Person("Juan", "Santiago", 9001);
Person spensir = new Person("Spensir", "Fields", 4);

List<Person> peopleList = new List<Person>(){
    adam,
    juan,
    spensir
};


List<string> aNames = names.Where(name => name.StartsWith("A") || name.StartsWith("s")).ToList();

// string missingName = names.First(name => name == "Not Alex Miller");
// string? missingName = names.FirstOrDefault(name => name == "Alex Miller");
// Console.WriteLine(missingName);

// foreach (string name in aNames)
// {
//     Console.WriteLine(name);
// }

List<Person> oldEnoughToDrinkInUSA = peopleList.Where(person => person.Age > 21 && !person.FirstName.ToLower().StartsWith("a")).ToList();

// foreach (Person p in oldEnoughToDrinkInUSA)
// {
//     Console.WriteLine(p.FirstName + " " + p.LastName);
// }

bool isAnyoneOlderThan100 = peopleList.Any(person => person.Age > 100);
bool isAnyoneYoungerThan4 = peopleList.Any(person => person.Age < 4);

// Console.WriteLine(isAnyoneOlderThan100);
// Console.WriteLine(isAnyoneYoungerThan4);



Movie interstellar = new Movie("Interstellar", "Spensir Fields");
Movie rushHour = new Movie("Rush Hour", "Juan Santiago");
Movie drStrange = new Movie("Dr. Strange: Multiverse", "Spensir Fields");


List<Movie> movies = new List<Movie>(){
    interstellar,
    rushHour,
    drStrange
};

var moviesAndActors = movies.
    Join(peopleList,  //joining movies w/ our list of people
    movie => movie.LeadActor,  //movie.LeadActor ==
    actor => actor.FullName(), // actor.FullName
    (movie, actor) => new { movie, actor }  //return a new dictionary w/ movie & actor inside of it
).ToList();


foreach (var movieWithActor in moviesAndActors)
{
    Console.WriteLine(movieWithActor.movie.Title + " starring: " + movieWithActor.actor.FullName() + " who is currently: " + movieWithActor.actor.Age);
}