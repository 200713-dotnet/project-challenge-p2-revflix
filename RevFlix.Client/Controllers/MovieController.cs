using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RevFlix.Client.Models;

namespace RevFlix.Client.Controllers
{

    public class MovieController : Controller
    {

        public IActionResult Index()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var client = new RestClient("http://localhost:5002/movie/imdbi/star");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IgnoreReadOnlyProperties = true
            };

            List<MovieIntModel> mvList = new List<MovieIntModel>();
            mvList = JsonConvert.DeserializeObject<List<MovieIntModel>>(response.Content);

            return View(mvList);
        }
        [HttpPost]
        public IActionResult IndexSearch(string userInput)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var client = new RestClient($"https://revflixservice.azurewebsites.net/movie/imdbi/{userInput}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IgnoreReadOnlyProperties = true
                };

                List<MovieIntModel> mvList = new List<MovieIntModel>();
                
                try
                {
                  mvList = JsonConvert.DeserializeObject<List<MovieIntModel>>(response.Content);
                }
                catch (Exception e)
                {
                  System.Console.WriteLine(e);
                }
                return View(mvList);
            
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return View("Error");
            }
        }

        public IActionResult DisplayDetails(string Imdb_id)
        {
            var client = new RestClient($"https://revflixservice.azurewebsites.net/movie/imdbs/1/{Imdb_id}");
            var request = new RestRequest(Method.GET);
            var client2 = new RestClient($"https://revflixservice.azurewebsites.net/movie/u/imdb/{Imdb_id}");
            IRestResponse response = client.Execute(request);
            IRestResponse response2 = client2.Execute(request);

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IgnoreReadOnlyProperties = true
                };

                DetailsViewModel mvList = new DetailsViewModel();
                mvList = JsonConvert.DeserializeObject<DetailsViewModel>(response.Content);

                List<SrcViewModel> srcList = new List<SrcViewModel>();
                // wrap this in try-catch so we can still return the correct View even if deserializer throws an exception
                // null fields should be skipped over in the view
                try
                {
                  ViewBag.srcList = JsonConvert.DeserializeObject<List<SrcViewModel>>(response2.Content);
                }
                catch (Exception e)
                {
                  System.Console.WriteLine(e);
                }
                
                return View(mvList);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return View("Error");
            }
        }
    }
}
