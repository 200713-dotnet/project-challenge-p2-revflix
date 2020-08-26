using System.Collections.Generic;

namespace RevFlix.Service.Models
{
  public class ImdbDetailsModel :MovieImdbModel
  {
    public string Description { get; set; }
    public List<string> Directors { get; set; }
    public List<string> Genres { get; set; }
    public string Imdb_Rating { get; set; }
    public List<string> Stars { get; set; }
    public string Status { get; set; }
    public string Status_message { get; set; }
    public string Youtube_Trailer_Key { get; set; }
    
  }
}