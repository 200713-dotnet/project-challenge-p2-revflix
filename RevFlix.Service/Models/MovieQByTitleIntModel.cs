using System.Collections.Generic;

namespace RevFlix.Service.Models
{
  public class MovieQByTitleIntModel : MovieQByTitleModelBase
  {
    public List<MovieImdbIntModel> Movie_Results { get; set; }
    public MovieQByTitleIntModel()
    {

    }
  }
}