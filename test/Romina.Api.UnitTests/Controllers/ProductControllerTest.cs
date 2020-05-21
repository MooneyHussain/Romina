﻿using System.Collections.Generic;
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

        private readonly Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
        private readonly Mock<IProductHandler> _productHandler = new Mock<IProductHandler>();

        private readonly Product _nikeTrouser = new Product
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
                .Returns(_nikeTrouser);

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

            _productRepository.Setup(pr => pr.GetProductById(BasicId)).Returns(It.IsAny<Product>());

            var result = productController.Get(BasicId);
            
            var expectedResult = new NotFoundResult();

            Assert.Null(result.Value);
            Assert.Equal(expectedResult.GetType(), result.Result.GetType());
        }

        [Fact]
        public void GetByQuery_WhenProductsExist_ReturnProducts()
        {
            List<Product> listOfProducts = new List<Product>();
            listOfProducts.Add(It.IsAny<Product>());
            listOfProducts.Add(It.IsAny<Product>());
            listOfProducts.Add(It.IsAny<Product>());

            var controller = new ProductController(_productRepository.Object, _productHandler.Object);
            _productHandler.Setup(ph => ph.GetProductsByFilter(BasicMake))
                .Returns(listOfProducts);

            var result = controller.GetByQuery(BasicMake);

            Assert.NotNull(result);
        }
        
        [Fact]
        public void GetByQuery_WhenProductsDontExist_ReturnEmptyList()
        {
            List<Product> listOfProducts = new List<Product>();

            var controller = new ProductController(_productRepository.Object, _productHandler.Object);

            _productHandler.Setup(ph => ph.GetProductsByFilter(BasicMake))
                .Returns(listOfProducts);

            var result = controller.GetByQuery(BasicMake);

            Assert.Empty(result);
        }
    }
}
