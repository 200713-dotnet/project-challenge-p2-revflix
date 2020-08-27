using System.Collections.Generic;

namespace RevFlix.Service.Models
{
  public class  UCollectionModel
  {
    public string Id { get; set; }
    public List<ULocationsModel> Locations{ get; set; }   //  array of source names, source icones and source urls
    public string Name { get; set; }                //  movie title
    public string Picture { get; set; }             //  movie poster image
  }
}