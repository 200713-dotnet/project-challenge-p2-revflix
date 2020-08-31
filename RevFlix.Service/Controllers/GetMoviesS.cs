using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RevFlix.Service.Models;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace RevFlix.Service.Controllers
{
  public class GetMoviesS
  {
    public string ImdbHost { get; set; }
    public string ImdbKey { get; set; }
    public SecretClient Client { get ; set; }
    // private string endptType = "";
    // private string Poster = "";
    // private string Fanart = "";

    public ImdbDetails2Model ImdbSDetails(string imdb_id, ref string message)
    {
      var options = new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true,
        };

      // get movie picture assets first
      try
      { 
        var endptType = "/?imdb=" + imdb_id + "&type=get-movies-images-by-imdb";
        var response = RestGet(endptType, "", ref message); 
        var mvList = JsonSerializer.Deserialize<ImdbDetails2Model>(response.Content, options);
        var Poster = mvList.Poster;
        var Fanart = mvList.Fanart;

        // get the bulk of the movie's details
        endptType = "/?imdb=" + imdb_id + "&type=get-movie-details";
        response = RestGet(endptType, "", ref message);
        mvList = JsonSerializer.Deserialize<ImdbDetails2Model>(response.Content, options);
        mvList.Poster = Poster;
        mvList.Fanart = Fanart;        
        return mvList;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return new ImdbDetails2Model();
      }

    }

    public List<MovieImdbModel> ImdbS(int id, ref string message)
    {
      var page = "1";
      var endpT = "";

      switch (id)
      {
        case 2:
          var year = DateTime.Today.Year;
          endpT = "/?type=get-popular-movies" + "&page=" + page + "&year=" + year;
          break;
        case 3:
          endpT = "/?page=" + page + "&type=get-trending-movies";
          break;
        case 4:
          endpT = "/?page=" + page + "&type=get-recently-added-movies";
          break;
        default:
          break;
      }

      var response = RestGet(endpT, "", ref message);

      try
      {
        var options = new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true,
        };

        var mvList = JsonSerializer.Deserialize<MovieQByTitleModel>(response.Content, options);
        return mvList.Movie_Results;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return new List<MovieImdbModel>();
      }

    }
    public GetMoviesS()
    {
      IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

      // ImdbHost = configuration["ApiParams:ImdbHost"];
      // ImdbKey = configuration["ApiParams:ImdbKey"];

      // --------- Leave these in here for Azure Secrets -----------
      Client = new SecretClient(new Uri("https://revflixkeyvault.vault.azure.net/"), new DefaultAzureCredential());
      KeyVaultSecret hostsecret = Client.GetSecret("revflix-p2-imdbhost");
      KeyVaultSecret keysecret = Client.GetSecret("revflix-p2-imdbkey");
      ImdbHost = hostsecret.Value;
      ImdbKey = keysecret.Value;
    }

    public IRestResponse RestGet(string endp, string stringp, ref string message)
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