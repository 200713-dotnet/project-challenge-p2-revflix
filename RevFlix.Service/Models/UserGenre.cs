namespace RevFlix.Service.Models
{
  public class UserGenre {
    public int Id { get; set; }
    public UserProfile UserProfile { get; set; }
    public Genre Genre { get; set; }

  }
}