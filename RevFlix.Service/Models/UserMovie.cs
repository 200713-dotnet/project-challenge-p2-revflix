namespace RevFlix.Service.Models
{
  public class UserMovie {
    public int Id { get; set; }
    public UserProfile UserProfile { get; set; }
    public Movie Movie { get; set; }

  }
}