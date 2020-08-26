using System;
using System.Text.Json;
using RevFlix.Service.Models;
using System.Collections.Generic;

namespace RevFlix.Service.Controllers
{
  public class GetMoviesI : GetMoviesS
  {
    public List<MovieImdbIntModel> ImdbI(string searchString, ref string message)
    {
      string endptType = "&type=get-movies-by-title";
      var title = "/?title=" + searchString.Replace(" ", "%20");
      var response = RestGet(endptType, title, ref message);
      try
      {
        var options = new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true,
        };

        var mvList = JsonSerializer.Deserialize<MovieQByTitleIntModel>(response.Content, options);

        return mvList.Movie_Results;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return new List<MovieImdbIntModel>();
      }
    }
  }
}