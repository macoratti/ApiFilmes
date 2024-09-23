namespace AspNetCoreRefitDemo.Models;

public class MovieDetails
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Overview { get; set; }
    public string? ReleaseDate { get; set; }
    public List<Genre>? Genres { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
}
