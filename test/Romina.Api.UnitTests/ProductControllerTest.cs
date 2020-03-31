using Moq;
using Romina.Api.Controllers;
using Romina.Api.Models;
using Romina.Api.Repositories;
using Xunit;

namespace Romina.Api.UnitTests
{
    public class ProductControllerTest
    {
        private string _basicId = "111";

        [Fact]
        public void GetId_WhenProductIdExists_ThenReturnProduct()
        {
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(pr => pr.GetProductById(_basicId))
                .Returns(new Product
                {
                    Description = " hat",
                    Make = "nike",
                    Model = "sport",
                    Price = 10.0,
                    ProductId = "111"
                });

            var productController = new ProductController(productRepository.Object);

            var result = productController.Get(_basicId);

            Assert.NotNull(result.Value);
            Assert.Equal(_basicId, result.Value.ProductId);
        }
    }
}
