using Microsoft.AspNetCore.Mvc;
using Moq;
using Romina.Api.Controllers;
using Romina.Api.Models;
using Romina.Api.Repositories;
using Xunit;

namespace Romina.Api.UnitTests
{
    public class ProductControllerTest
    {
        private const string BasicId = "111";

        [Fact]
        public void GetId_WhenProductIdExists_ThenReturnProduct()
        {
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(pr => pr.GetProductById(BasicId))
                .Returns(new Product
                {
                    Description = " hat",
                    Make = "nike",
                    Model = "sport",
                    Price = 10.0,
                    ProductId = "111"
                });

            var productController = new ProductController(productRepository.Object);

            var result = productController.Get(BasicId);

            Assert.NotNull(result.Value);
            Assert.Equal(BasicId, result.Value.ProductId);
        }

        [Fact]
        public void GetId_WhenProductIdDoesNotExist_ThenReturnNotFound()
        {
            var productRepository = new Mock<IProductRepository>();
            var controller = new ProductController(productRepository.Object);
            productRepository.Setup(pr => pr.GetProductById(BasicId)).Returns(new
                Product
                {

                });

            var result = controller.Get("999");
            var expectedResult = new NotFoundResult();

            Assert.Null(result.Value);
            Assert.Equal(expectedResult.GetType(), result.Result.GetType());
        }
    }
}
