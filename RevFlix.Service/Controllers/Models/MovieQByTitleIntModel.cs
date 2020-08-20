using System.Collections.Generic;

namespace RevFlix.Service.Controllers.Models
{
  public class MovieQByTitleIntModel : MovieQByTitleModelBase
  {
    public List<MovieImdbIntModel> Movie_Results { get; set; }
    public MovieQByTitleIntModel()
    {

    }
  }
}