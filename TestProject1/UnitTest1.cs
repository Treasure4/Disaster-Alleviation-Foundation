using Disaster_Alleviation_Foundation.Controllers;
using Disaster_Alleviation_Foundation.Data;
using Disaster_Alleviation_Foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;  // Make sure to include this for xUnit

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AllocateGoods_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var disasterContextMock = new Mock<DisasterContext>();

           
            var goodsAllocationModelMock = new Mock<GoodsAllocationModel>();

            HomeController controller = new HomeController(loggerMock.Object, disasterContextMock.Object);

            // Act
            ActionResult result = controller.AllocateGoods(goodsAllocationModelMock.Object);

            // Assert using xUnit's Assert
            Xunit.Assert.IsType<ViewResult>(result);
        }
    }
}
