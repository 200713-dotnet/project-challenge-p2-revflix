using Microsoft.AspNetCore.Mvc;
using RevFlix.Client.Controllers;
using Xunit;

namespace RevFlix.Testing.Tests
{
  public class MovieTestsController
  {
    [Theory]
    [InlineData("ad astra","tt2935510")]
    [InlineData("hgfdsa","star")]
    public void Test_MovieController(string title, string id)
    {
      //arrange
      var sut = new MovieController();

      //act
      var view = sut.IndexSearch(title);
      var view2 = sut.DisplayDetails(id);

      //assert
      Assert.NotNull(view);
      Assert.NotNull(view2);

    }
  }
}