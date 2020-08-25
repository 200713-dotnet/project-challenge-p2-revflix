using Microsoft.AspNetCore.Mvc;
using RevFlix.Service.Controllers;
using Xunit;

namespace RevFlix.Testing.Tests
{
  public class ImdbiControllerTest
  {
    [Theory]
    [InlineData("ad astra")]
    [InlineData("hgfdsa")]
    public void Test_ImdbiController(string title)
    {
      //arrange
      var sut = new ImdbiController();

      //act
      var actionResult = sut.Get(title);

      var okResult = actionResult as OkObjectResult;
      System.Console.WriteLine($"OkObjectResult Status Code: {okResult.StatusCode}");
      
      //assert
      Assert.True(okResult.StatusCode == 200);

    }
  }
}