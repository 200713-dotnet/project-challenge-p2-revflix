using System.Collections.Generic;

namespace RevFlix.Service.Controllers.Models
{
  public class MovieQByTitleModel : MovieQByTitleModelBase
  {
    public List<MovieImdbModel> Movie_Results { get; set; }
    public MovieQByTitleModel()
    {

    }
  }
}