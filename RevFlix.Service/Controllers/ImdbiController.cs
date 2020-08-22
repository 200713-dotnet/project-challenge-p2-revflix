using Microsoft.AspNetCore.Mvc;

namespace RevFlix.Service.Controllers
{
  [Route("/movie/imdbi/{title}")]
  // [EnableCors("private")]  
  public class ImdbiController : ControllerBase
  {

    [HttpGet]
    public IActionResult Get(string title)
    {
      var movies = new GetMoviesI();
      string message = null;
      var list = movies.ImdbI(title, message);
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
