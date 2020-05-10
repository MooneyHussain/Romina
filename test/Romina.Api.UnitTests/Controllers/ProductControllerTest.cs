using Microsoft.AspNetCore.Mvc;
using Moq;
using Romina.Api.Controllers;
using Romina.Api.Handlers;
using Romina.Api.Models;
using Romina.Api.Repositories;
using Xunit;

namespace Romina.Api.UnitTests.Controllers
{
    public class ProductControllerTest
    {
        private const string BasicId = "111";
        private const string BasicMake = "Nike";
        private const string BasicModel = "sport";

        private readonly Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
        private readonly Mock<IProductHandler> _productHandler = new Mock<IProductHandler>();

        private Product _product = new Product
        {
            Description = " trouser",
            Make = "Nike",
            Model = "sport",
            Price = 16.0,
            ProductId = "111"
        };

        [Fact]
        public void GetId_WhenProductIdExists_ThenReturnProduct()
        {
            _productRepository.Setup(pr => pr.GetProductById(BasicId))
                .Returns(_product);

            var productController = new ProductController(
                _productRepository.Object, 
                _productHandler.Object);

            var result = productController.Get(BasicId);

            Assert.NotNull(result.Value);
            Assert.Equal(BasicId, result.Value.ProductId);
        }

        [Fact]
        public void GetId_WhenProductIdDoesNotExist_ThenReturnNotFound()
        {
            var productController = new ProductController(
                _productRepository.Object,
                _productHandler.Object);

            _productRepository.Setup(pr => pr.GetProductById(BasicId)).Returns(new
                Product());

            var result = productController.Get("999"); //is this string supposed to be BasicId
            
            var expectedResult = new NotFoundResult();

            Assert.Null(result.Value);
            Assert.Equal(expectedResult.GetType(), result.Result.GetType());
        }

        [Fact(Skip = "Dan to complete - Once done remove this line and uncomment the line below")]
        //[Fact]
        public void GetByQuery_WhenProductsExist_ReturnProducts()
        {
            // ARRANGE
            // create controller 
            // set up the _productHandler to return a list of products 

            // ACT 
            // call GetByQuery method on productController

            // ASSERT 
            // assert that the list returned is not null / empty
        }
    }
}
