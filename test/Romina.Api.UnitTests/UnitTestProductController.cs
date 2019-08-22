using NSubstitute;
using Romina.Api.Controllers;
using Romina.Api.Model;
using Romina.Api.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Romina.Api.UnitTests
{
    public class UnitTestProductController
    {
        private ICosmosDbService cosmosDBService;
        private ProductController productController;
        private string productID;

        public UnitTestProductController()
        {
            cosmosDBService = Substitute.For<ICosmosDbService>();
            productController = new ProductController(cosmosDBService);
            productID = "abc1234";
        }
      
        [Fact]
        public async Task Get_WhenProductExistThenReturnProductAsync()
        {
            var product = new Product() { ProductId = productID, Make = "Adidas", Model = "model", Price = 10.00, Description = "" };

            cosmosDBService.GetProduct(productID).Returns(product);

            var result = await productController.Get(productID);

            Assert.Same(product, result.Value);
        }

        [Fact]
        public async Task Get_WhenProductDoesNotExistThenReturnNotFound()
        {
            var result = await productController.Get(productID);

            Assert.Null(result.Value);
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Get_WhenExceptionIsThrownThenReturnExceptionMessageAsync()
        {
            cosmosDBService.When(x => x.GetProduct(productID))
                           .Do(x => throw new Exception("exception"));

            await Assert.ThrowsAsync<Exception>(async () => await productController.Get(productID));
        }
    }
}
