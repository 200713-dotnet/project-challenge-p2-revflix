using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RevFlix.Service.Controllers.Models;

namespace RevFlix.Service.Controllers
{
  [Route("/movie/imdbs/{id}/{imdb_id}")]
  // [EnableCors("private")]  
  public class ImdbsController : ControllerBase
  {

    [HttpGet]
    public IActionResult Get(int id, string imdb_id = null)
    {
      var movies = new GetMoviesS();
      string message = null;
      var list1 = new ImdbDetailsModel();
      var list2 = new List<MovieImdbModel>();


      if (id == 1)
      {
        // imdb_id = "";
        list1 = movies.ImdbSDetails(imdb_id, message);
        if (message != null)
        {
          return Ok(message);
        }

        if (list1 == null)
        {
          return Ok("Your search did not return any results.");
        }
        return Ok(list1);
      }
      else
      {
        // imdb_id = "";        
        list2 = movies.ImdbS(id, message);
        if (message != null)
        {
          return Ok(message);
        }

        if (list2 == null)
        {
          return Ok("Your search did not return any results.");
        }
        return Ok(list2);
      }

    }

    [HttpPost]
    public IActionResult Post()
    {
      return Ok();
    }
  }
}

