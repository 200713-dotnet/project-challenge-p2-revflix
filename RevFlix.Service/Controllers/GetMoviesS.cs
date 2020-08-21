using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RevFlix.Service.Controllers.Models;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace RevFlix.Service.Controllers
{
  public class GetMoviesS
  {
    public string ImdbHost { get; set; }
    public string ImdbKey { get; set; }

    public ImdbDetailsModel ImdbSDetails(string imdb_id, string message)
    {

      var endptType = "/?imdb=" + imdb_id + "&type=get-movie-details";

      imdb_id = "";
      var response = RestGet(endptType, imdb_id, message);

      try
      {
        var options = new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true,
        };

        ImdbDetailsModel mvList = new ImdbDetailsModel();
        mvList = JsonSerializer.Deserialize<ImdbDetailsModel>(response.Content, options);
        return mvList;

      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }

    }

    public List<MovieImdbModel> ImdbS(int id, string message)
    {
      var page = "1";
      var endptType = "";

      switch (id)
      {
        case 2:
          var year = DateTime.Today.Year;
          endptType = "/?type=get-popular-movies" + "&page=" + page + "&year=" + year;
          break;
        case 3:
          endptType = "/?page=" + page + "&type=get-trending-movies";
          break;
        case 4:
          endptType = "/?page=" + page + "&type=get-recently-added-movies";
          break;
        default:
          break;
      }

      var response = RestGet(endptType, "", message);

      try
      {
        var options = new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true,
        };

        MovieQByTitleModel mvList = new MovieQByTitleModel();
        mvList = JsonSerializer.Deserialize<MovieQByTitleModel>(response.Content, options);
        return mvList.Movie_Results;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }

    }
    public GetMoviesS()
    {
      IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

      ImdbHost = configuration["ApiParams:ImdbHost"];
      ImdbKey = configuration["ApiParams:ImdbKey"];
    }

    public IRestResponse RestGet(string endp, string stringp, string message)
    {
      var url = ImdbHost;
      url = "https://" + url;
      url += stringp + endp;
      var client = new RestClient(url);
      var request = new RestRequest(Method.GET);
      request.AddHeader("x-rapidapi-host", ImdbHost);
      request.AddHeader("x-rapidapi-key", ImdbKey);
      IRestResponse response = client.Execute(request);

      if (response.StatusCode != HttpStatusCode.OK)
      {
        message = "Request failed with status code "
                   + response.StatusCode + ", and content: " + response.Content;
      }

      return response;
    }

  }
}