using System.Collections.Generic;

namespace RevFlix.Service.Models
{
  public class Movie {
    public int Id { get; set; }
    public List<UserMovie> UserMovies { get; set; }
    public string MovieDetails { get; set; }

  }
}