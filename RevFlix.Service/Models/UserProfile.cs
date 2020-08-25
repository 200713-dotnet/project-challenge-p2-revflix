using System.Collections.Generic;

namespace RevFlix.Service.Models
{
  public class UserProfile {
    public int Id { get; set; }
    public string UserId { get; set; }
    public List<UserGenre> UserGenres { get; set; }
    public List<UserMovie> WatchList { get; set; }

  }
}