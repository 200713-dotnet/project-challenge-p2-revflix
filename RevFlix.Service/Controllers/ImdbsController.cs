using Microsoft.AspNetCore.Mvc;

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

      if (id == 1)
      {
        var list1 = movies.ImdbSDetails(imdb_id, ref message);
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
        var list2 = movies.ImdbS(id, ref message);
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

