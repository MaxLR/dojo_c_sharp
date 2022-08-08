public class Movie {
    public string Title { get; set; }
    public string LeadActor { get; set; }

    public Movie(string title, string lead)
    {
        Title = title;
        LeadActor = lead;
    }
}