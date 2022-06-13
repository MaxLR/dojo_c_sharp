List<Movie> movies = new List<Movie> {
    new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
    new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
    new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
    new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
    new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
    new Movie("The Martian", "Matt Damon", 8, 2015),
};

List<Actor> actors = new List<Actor> {
    new Actor { FullName = "Matt Damon", Age = 48 },
    new Actor { FullName = "matt Broderick", Age = 55 },
    new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
};


// IEnumerable<Actor> mattActors = actors.Where(actor => actor.FullName.Contains("matt") || actor.FullName.Contains("Matt"));

// foreach (Actor a in mattActors)
// {
//     Console.WriteLine(a.FullName);
// };


// IEnumerable<Movie> moviesByRating = movies.OrderByDescending(movie => movie.Rating);


// double highestRating = movies.Max(movie => movie.Rating);

// Movie? highestRatedMovie = movies.FirstOrDefault(movie => movie.Rating == highestRating);

// if (highestRatedMovie != null) {
//     Console.WriteLine(highestRatedMovie.ToString());
// }

// Console.WriteLine(highestRating);

// foreach (Movie m in moviesByRating)
// {
//     Console.WriteLine(m.ToString());
// }


// Creating a list of movies after 2000 ordered by title descending
// IEnumerable<Movie> orderedNewishMovies = movies.Where(movie => movie.Year > 2000).OrderByDescending(movie => movie.Title);

// foreach (Movie m in orderedNewishMovies)
// {
//     Console.WriteLine(m.ToString());
// }


var moviesAndActor = movies
    .Join(actors, //lets us join actors list
    movie => movie.LeadActor, // specifies property from table 1 to join onto table 2
    actor => actor.FullName, // specifies property from table 2
    (movie, actor) => new { movie, actor } //return a new dictionary w/ a movie & actor inside
).Where(movieAndActor => movieAndActor.actor.FullName == "Leonardo DiCaprio")
.ToList();

Console.WriteLine(moviesAndActor[0].actor.FullName);
Console.WriteLine(moviesAndActor[0].movie.ToString());