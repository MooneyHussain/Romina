using System.Collections.Generic;
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
        private const string BasicMake = "Nike";
        private const string BasicModel = "sport";

        private static readonly Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();

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

            var productController = new ProductController(_productRepository.Object);

            var result = productController.Get(BasicId);

            Assert.NotNull(result.Value);
            Assert.Equal(BasicId, result.Value.ProductId);
        }

        [Fact]
        public void GetId_WhenProductIdDoesNotExist_ThenReturnNotFound()
        {
            var controller = new ProductController(_productRepository.Object);
            _productRepository.Setup(pr => pr.GetProductById(BasicId)).Returns(new
                Product
                {

                });

            var result = controller.Get("999"); //is this string supposed to be BasicId
            var expectedResult = new NotFoundResult();

            Assert.Null(result.Value);
            Assert.Equal(expectedResult.GetType(), result.Result.GetType());
        }

        [Fact]
        public void GetMake_WhenProductMakeExists_ThenReturnProduct()
        {
            var controller = new ProductController(_productRepository.Object);
            _productRepository.Setup(pr => pr.GetProductByMake(BasicMake))
                .Returns(_product);

            var result = controller.GetByMake(BasicMake);

            Assert.NotNull(result.Value);
            Assert.Equal(BasicMake, result.Value.Make);
        }

        [Fact]
        public void GetMake_WhenProductMakeDoesNotExist_ThenReturnProduct()
        {
            var productRepository = new Mock<IProductRepository>();
            var controller = new ProductController(productRepository.Object);
            productRepository.Setup(pr => pr.GetProductByMake("Adidas"))
                .Returns(new Product {});

            var result = controller.GetByMake("Adidas");
            var expectedResult = new NotFoundResult();

            Assert.Null(result.Value);
            Assert.Equal(expectedResult.GetType(), result.Result.GetType());
        }

        [Fact]
        public void GetModel_WhenProductModelExists_ThenReturnProduct()
        {
            var controller = new ProductController(_productRepository.Object);
            _productRepository.Setup(pr => pr.GetProductByModel(BasicModel))
                .Returns(_product);

            var result = controller.GetByModel(BasicModel);

            Assert.NotNull(result.Value);
            Assert.Equal(BasicModel, result.Value.Model);
        }
    }
}
