using Romina.Api.Controllers;
using Xunit;

namespace Romina.Api.UnitTests
{
    public class ProductControllerTest
    {
        [Fact]
        public void GetId_WhenProductIdExists_ThenReturnProduct()
        {
            var productController = new ProductController();
            var result = productController.Get("111");
            Assert.NotNull(result.Value);
            Assert.Equal("111", result.Value.ProductId);
        }
    }
}
