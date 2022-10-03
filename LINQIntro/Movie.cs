public class Movie
{
  public string Title { get; set; }
  public string LeadActor { get; set; }
  public double Rating { get; set; }
  public int Year { get; set; }

  public Movie(string title, string leadActor, double rating, int year)
  {
    Title = title;
    LeadActor = leadActor;
    Rating = rating;
    Year = year;
  }

  public override string ToString()
  {
    return $@"
    Title:     {Title}
    LeadActor: {LeadActor}
    Rating:    {Rating}
    Year:      {Year}";
  }
}