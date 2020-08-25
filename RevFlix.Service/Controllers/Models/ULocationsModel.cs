using System.Collections.Generic;

namespace RevFlix.Service.Controllers.Models
{
  public class ULocationsModel
  {
    // public List<UCountryModel> Country { get; set; }
    public string Display_Name { get; set; }  //  source name (Netflix, etc.)
    public string Icon { get; set; }          //  source icon
    public string Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }           // link to the movie
  }
}