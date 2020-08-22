using System.Collections.Generic;

namespace RevFlix.Client.Models
{
  public class MovieViewModel : ListViewModel
  {
    public List<MovieIntModel> Movie_Results { get; set; }
    public MovieViewModel()
    {
      
    }
  }
}