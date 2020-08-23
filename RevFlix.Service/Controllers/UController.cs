using Microsoft.AspNetCore.Mvc;

namespace RevFlix.Service.Controllers
{
  [Route("/movie/u/imdb/{src_id}")]
  // [EnableCors("private")]  
  public class UController : ControllerBase
  {

    [HttpGet]
    public IActionResult Get(string src_id)
    {
      var movies = new GetMoviesU();
      string message = null;
      var list = movies.ULocationDetails(src_id, message);
      if (message != null)
      {
        return Ok(message);
      }

      if (list == null)
      {
        return Ok("Your search did not return any results.");
      }
      return Ok(list);

      // return Ok($"RevFlix API service: You search for the movie '{srch}.'");

    }

    [HttpPost]
    public IActionResult Post()
    {
      return Ok();
    }
  }
}

