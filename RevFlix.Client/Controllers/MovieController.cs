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
            request.AddHeader("x-rapidapi-host", "localhost");
            request.AddHeader("x-rapidapi-key", "971bf2ac6fmsh604c84512ded1eap16b86fjsn950b74fe77a7");
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
            var client = new RestClient($"http://localhost:5002/movie/imdbi/{userInput}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "localhost");
            request.AddHeader("x-rapidapi-key", "971bf2ac6fmsh604c84512ded1eap16b86fjsn950b74fe77a7");
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
    }
}
