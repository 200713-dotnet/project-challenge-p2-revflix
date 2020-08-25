using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevFlix.Client.Controllers;
using Xunit;

namespace RevFlix.Testing.Tests
{
  public class UserTestController
  {
    [Fact]
    public void UserController_Test()
    {
      var sut = new UserController();
      var view = sut.Index();

      Assert.NotNull(view);
    }
  }
}