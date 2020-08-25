using System;
using Microsoft.Extensions.Configuration;
using RevFlix.Service.Controllers.Models;
using RestSharp;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace RevFlix.Service.Controllers
{
  public class GetMoviesU
  {
    public string UtellyHost { get; set; }
    public string UtellyKey { get; set; }
    public SecretClient Client { get; set; }

    public IList<ULocationsModel> ULocationDetails(string imdb_id, ref string message)
    {

      var endptType = "/idlookup?source_id=" + imdb_id + "&source=imdb";

      var response = RestGet(endptType, ref message);

      var json1 = "collection";
      var json2 = "locations";

      if (!response.Content.Contains(json2))
      {
        message = "Your search did not return any locations for that movie.";
        return new List<ULocationsModel>();
      }
      else
      {
        try
        {
          JObject uDetails = JObject.Parse(response.Content);
          //get JSON result objects into a list
          IList<JToken> results = uDetails[json1][json2].Children().ToList();
          // serialize JSON results into .NET objects
          IList<ULocationsModel> searchResults = new List<ULocationsModel>();
          foreach (JToken result in results)
          {
            // JToken.ToObject is a helper method that uses JsonSerializer internally
            ULocationsModel searchResult = result.ToObject<ULocationsModel>();
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



    }
    public GetMoviesU()
    {
      var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

      // UtellyHost = configuration["ApiParams:UtellyHost"];
      // UtellyKey = configuration["ApiParams:UtellyKey"];

      // --------- Leave these in here for Azure Secrets -----------
      Client = new SecretClient(new Uri("https://revflixkeyvault.vault.azure.net/"), new DefaultAzureCredential());
      KeyVaultSecret hostsecret = Client.GetSecret("revflix-p2-utellyhost");
      KeyVaultSecret keysecret = Client.GetSecret("revflix-p2-utellykey");
      UtellyHost = hostsecret.Value;
      UtellyKey = keysecret.Value;

    }

    public IRestResponse RestGet(string endp, ref string message)
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