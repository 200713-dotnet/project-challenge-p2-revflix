using Microsoft.AspNetCore.Mvc;

namespace RevFlix.Service.Controllers
{
  [Route("/movie/imdbi/{srch}")]
  // [EnableCors("private")]  
  public class ImdbiController : ControllerBase
    {
  //   private readonly RevFlixDbContext _db;

  //   public MovieController(RevFlixDbContext dbContext) // constructor dependency injection
  //   {
  //     _db = dbContext;
  //   }

    [HttpGet]
    public IActionResult Get(string srch)
    {
      var movies = new GetMovies();
      string message = null;
      var list = movies.GetMoviesImdbI(srch, message);
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

