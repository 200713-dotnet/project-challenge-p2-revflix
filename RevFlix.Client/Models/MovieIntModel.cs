using System.Collections.Generic;

namespace RevFlix.Client.Models
{
  public class MovieIntModel
  {
    public int Year { get; set; }
    public string Title { get; set; }

    public string Imdb_id { get; set; }
    public MovieIntModel()
    {

    }
  }

  public class Root
  {
      public List<MovieIntModel> MovieIntModel { get; set; }
  }
}