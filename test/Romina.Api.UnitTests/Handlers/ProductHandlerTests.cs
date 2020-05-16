using System.Collections.Generic;
using Moq;
using Romina.Api.Handlers;
using Romina.Api.Models;
using Romina.Api.Repositories;
using Xunit;

namespace Romina.Api.UnitTests.Handlers
{
    public class ProductHandlerTests
    {
        private Mock<IProductRepository> _productRepository;
        private const string filter = "nike";

        private readonly Product _nikeTrouser = new Product
        {
            Description = " trouser",
            Make = "nike",
            Model = "sport",
            Price = 16.0,
            ProductId = "111"
        };

        private readonly Product _nikeHat = new Product
        {
            Description = "nike",
            Make = "Angola",
            Model = "sport",
            Price = 14.0,
            ProductId = "112"
        };
        
        private readonly Product _nikeGlove = new Product
        {
            Description = "glove",
            Make = "Jacamo",
            Model = "nike",
            Price = 11.0,
            ProductId = "113"
        };

        public ProductHandlerTests()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public void GetProductsByFilter_WhenProductsExist_OrderByMakeThenModelThenDescrption()
        {
            var filter = "nike";
            var handler = new ProductHandler(_productRepository.Object);


            List<Product> listOfProducts = new List<Product>();
            listOfProducts.Add(_nikeTrouser);
            listOfProducts.Add(_nikeGlove);
            listOfProducts.Add(_nikeHat);

            _productRepository.Setup(pr => pr.Query(filter)).Returns(listOfProducts);

            var result = handler.GetProductsByFilter(ProductHandlerTests.filter);

            Assert.NotNull(listOfProducts[0]);
            Assert.NotNull(listOfProducts[1]);
            Assert.NotNull(listOfProducts[2]);
            
            Assert.Equal(filter, listOfProducts[0].Make);
            Assert.Equal(filter, listOfProducts[1].Model);
            Assert.Equal(filter, listOfProducts[2].Description);
        }
    }
}
