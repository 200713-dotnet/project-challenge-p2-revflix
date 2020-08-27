using System.Collections.Generic;

namespace RevFlix.Service.Models
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