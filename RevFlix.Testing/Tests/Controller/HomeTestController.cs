using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevFlix.Client.Controllers;
using Xunit;

namespace RevFlix.Testing.Tests
{
  public class HomeTestController
  {
    private ILogger<HomeController> _logger = LoggerFactory.Create(options => options.AddConsole()).CreateLogger<HomeController>();

    [Fact]
    public void HomeController_Test()
    {
      var sut = new HomeController(_logger);
      var view = sut.Index();
      var view2 = sut.Privacy();

      Assert.NotNull(view);
      Assert.NotNull(view2);
    }
  }
}