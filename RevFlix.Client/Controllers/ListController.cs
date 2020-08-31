using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RevFlix.Client.Models;

namespace RevFlix.Client.Controllers
{
    public class ListController : Controller
    {
        public IActionResult Index()
        {
            string Imdb_id = Convert.ToString(TempData["id"]);
            var client = new RestClient($"https://revflixservice.azurewebsites.net/movie/imdbs/1/{Imdb_id}");
            var request = new RestRequest(Method.GET);
            var client2 = new RestClient($"https://revflixservice.azurewebsites.net/movie/u/imdb/{Imdb_id}");
            IRestResponse response = client.Execute(request);
            IRestResponse response2 = client2.Execute(request);

            // var options = new JsonSerializerOptions
            // {
            //     PropertyNameCaseInsensitive = true,
            //     IgnoreReadOnlyProperties = true
            // };

            // DetailsViewModel mvList = new DetailsViewModel();
            var mvList = new DetailsViewModel();
            mvList = JsonConvert.DeserializeObject<DetailsViewModel>(response.Content);

            // List<SrcViewModel> srcList = new List<SrcViewModel>();
            var srcList = new List<SrcViewModel>();
            ViewBag.srcList = JsonConvert.DeserializeObject<List<SrcViewModel>>(response2.Content);

            return View(mvList);
        }
        public IActionResult AddToList(string Imdb_id)
        {
            var client = new RestClient($"http://revflixservice.azurewebsites.net/movie/imdbs/1/{Imdb_id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            
            // var options = new JsonSerializerOptions
            // {
            //     PropertyNameCaseInsensitive = true,
            //     IgnoreReadOnlyProperties = true
            // };

            // DetailsViewModel mvList = new DetailsViewModel();
            var mvList = new DetailsViewModel();
            mvList = JsonConvert.DeserializeObject<DetailsViewModel>(response.Content);
            TempData["id"] = mvList.imdb_id;

            return RedirectToAction("Index");
        }
    }
}