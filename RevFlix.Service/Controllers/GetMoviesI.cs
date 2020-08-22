using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RevFlix.Service.Controllers.Models;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace RevFlix.Service.Controllers
{
  public class GetMoviesI : GetMoviesS
  {
    public List<MovieImdbIntModel> ImdbI(string searchString, string message)
    {
      string endptType = "&type=get-movies-by-title";
      var title = "/?title=" + searchString.Replace(" ", "%20");
      var response = RestGet(endptType, title, message);
      try
      {
        var options = new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true,
        };

        MovieQByTitleIntModel mvList = new MovieQByTitleIntModel();
        mvList = JsonSerializer.Deserialize<MovieQByTitleIntModel>(response.Content, options);

        return mvList.Movie_Results;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        // var message = "The RevFlix service did not return any result or encountered an error";
        return null;
      }
    }
  }
}