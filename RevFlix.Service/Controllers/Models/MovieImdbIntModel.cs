namespace RevFlix.Service.Controllers.Models
{
  public class MovieImdbIntModel : MovieImdbModelBase
  {
    public int Year { get; set; }
    public MovieImdbIntModel()
    {

    }
    public override string ToString()
    {
      return $"Imdb ID: {Imdb_id}, Title: {Title}, Year: {Year}";
    }    
  }
}