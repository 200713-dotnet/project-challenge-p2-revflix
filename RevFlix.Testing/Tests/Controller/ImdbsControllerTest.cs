using Microsoft.AspNetCore.Mvc;
using RevFlix.Service.Controllers;
using Xunit;

namespace RevFlix.Testing.Tests
{
  public class ImdbsControllerTest
  {
    [Theory]
    [InlineData(1, "tt2935510")]
    [InlineData(1, "hgfdsa")]
    [InlineData(2, "dummy text")]
    [InlineData(3, "dummy text")]
    [InlineData(4, "dummy text")]
    public void Test_ImdbsController(int id, string title)
    {
      //arrange
      var sut = new ImdbsController();

      //act
      var actionResult = sut.Get(id, title);

      var okResult = actionResult as OkObjectResult;
      System.Console.WriteLine($"OkObjectResult Status Code: {okResult.StatusCode}");
      
      //assert
      Assert.True(okResult.StatusCode == 200);

    }
  }
}