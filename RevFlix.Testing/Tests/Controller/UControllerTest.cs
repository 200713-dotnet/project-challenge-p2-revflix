using Microsoft.AspNetCore.Mvc;
using RevFlix.Service.Controllers;
using Xunit;

namespace RevFlix.Testing.Tests
{
  public class UControllerTest
  {
    [Theory]
    [InlineData("tt2935510")]
    [InlineData("tt0000000")]
    public void Test_ImdbiController(string imdb_id)
    {
      //arrange
      var sut = new ImdbiController();

      //act
      var actionResult = sut.Get(imdb_id);

      var okResult = actionResult as OkObjectResult;
      System.Console.WriteLine($"OkObjectResult Status Code: {okResult.StatusCode}");
      
      //assert
      Assert.True(okResult.StatusCode == 200);

    }
  }
}