using System.Collections.Generic;

namespace RevFlix.Service.Controllers.Models
{
  public class USourceIdsModel
  {
    public List<UImdbModel> Imdb { get; set; }
    public USourceIdsModel()
    {
      Imdb = new List<UImdbModel>();
    }
  }
}