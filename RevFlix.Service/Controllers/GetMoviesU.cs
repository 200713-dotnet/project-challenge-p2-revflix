using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RevFlix.Service.Controllers.Models;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace RevFlix.Service.Controllers
{
  public class GetMoviesU
  {
    public string UtellyHost { get; set; }
    public string UtellyKey { get; set; }

    public IList<ULocationsModel> ULocationDetails(string imdb_id, string message)
    {

      var endptType = "/idlookup?source_id=" + imdb_id + "&source=imdb";

      var response = RestGet(endptType, message);

      try
      {       
        JObject uDetails = JObject.Parse(response.Content);
        //get JSON result objects into a list
        IList<JToken> results = uDetails["collection"]["locations"].Children().ToList();
        // serialize JSON results into .NET objects
        IList<ULocationsModel> searchResults = new List<ULocationsModel>();
        foreach (JToken result in results)
        {
          // JToken.ToObject is a helper method that uses JsonSerializer internally
          ULocationsModel searchResult = result.ToObject<ULocationsModel>();
          // searchResult.MovieTitle = mvTitle;
          // searchResult.MoviePicture = mvPicture;
          searchResults.Add(searchResult);
        }

        return searchResults;

      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }

    }
    public GetMoviesU()
    {
      IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

      UtellyHost = configuration["ApiParams:UtellyHost"];
      UtellyKey = configuration["ApiParams:UtellyKey"];
    }

    public IRestResponse RestGet(string endp, string message)
    {
      var url = UtellyHost;
      url = "https://" + url + endp;
      var client = new RestClient(url);
      var request = new RestRequest(Method.GET);
      request.AddHeader("x-rapidapi-host", UtellyHost);
      request.AddHeader("x-rapidapi-key", UtellyKey);
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