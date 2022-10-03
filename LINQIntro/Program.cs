void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);

    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

List<int> numbers = new List<int>()
{
  5, 15, 20, 0, 1, 3, 25
};

//filtering out numbers that aren't greater than 10
List<int> numsAboveTen = numbers.Where(num => num > 10).ToList();
// Console.WriteLine(String.Join(", ", numsAboveTen));


List<string> names = new List<string>()
{
  "Neil", "Mark", "Lauren", "Jake", "Adam", "Garrett"
};

int minNameLength = names.Min(name => name.Length);
int maxNameLength = names.Max(name => name.Length);
// Console.WriteLine(minNameLength);
// Console.WriteLine(maxNameLength);


List<Movie> movies = new List<Movie> {
    new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
    new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
    new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
    new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
    new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
    new Movie("The Martian", "Matt Damon", 8, 2015),
};

List<Actor> actors = new List<Actor> {
    new Actor { FullName = "Matt Damon", Age = 48 },
    new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
};


// You should use FirstOrDefault since it will return a value, or null when the object doesn't exist
// using First will cause your server to error out, if that value isn't in your collection
// Movie selectedMovie = movies.First(m => m.Title == "Blood Diamond");
Movie? selectedMovie = movies.FirstOrDefault(m => m.Title == "Blood Diamond");
if (selectedMovie != null)
{
  // Console.WriteLine(selectedMovie.ToString());
}

selectedMovie = movies.FirstOrDefault(m => m.Rating == 8.5);
//.ToString() is invoked automatically if it exists when console logging an object
// Console.WriteLine(selectedMovie);

// you can do the .Min query separately above as well instead of putting all on one line
Movie? oldestMovie = movies.FirstOrDefault(m => m.Year == movies.Min(movie => movie.Year));
// Console.WriteLine(oldestMovie);

bool isAnyMovieRatedAbove9 = movies.Any(m => m.Rating > 9);
Console.WriteLine($"Is any movie rated above 9? {isAnyMovieRatedAbove9}");

List<Movie> filteredMovies = movies.OrderByDescending(m => m.Title).ToList();

// can chain linq queries, see below
filteredMovies = movies.Where(m => m.LeadActor == "Leonardo DiCaprio").OrderByDescending(m => m.Title).ToList();
// filteredMovies = filteredMovies.OrderByDescending(m => m.Title).ToList();

filteredMovies = movies.Where(m => m.LeadActor.StartsWith("Russ") && m.Year > 2000).ToList();

PrintEach(filteredMovies);

//.Select allows us to retrieve only some of the info for each object
var selected = movies.Select(m => m.Title);


//filtering movies that the main actor is matt damon & selecting ONLY the title to then print
selected = movies
  .Where(m => m.LeadActor == "Matt Damon")
  .Select(m => m.Title)
  .OrderBy(title => title)
  .ToList();
PrintEach(selected);