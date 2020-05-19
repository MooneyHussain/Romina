using System.Collections.Generic;
using System.Linq;
using Moq;
using Romina.Api.Handlers;
using Romina.Api.Models;
using Romina.Api.Repositories;
using Xunit;

namespace Romina.Api.UnitTests.Handlers
{
    public class ProductHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private const string Filter = "nike";

        public ProductHandlerTests()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public void GetProductsByFilter_WhenProductsExist_OrderByMakeThenModelThenDescrption()
        {
            var handler = new ProductHandler(_productRepository.Object);
            var nikeTrouser = CreateProduct("nike", "sport", "111", "trouser", 16.0);
            var nikeGlove = CreateProduct("Jacamo", "nike", "113", "glove", 11);
            var nikeHat = CreateProduct("Angola", "sport", "113", "nike", 14);

            List<Product> listOfProducts = new List<Product> {nikeTrouser, nikeGlove, nikeHat};

            _productRepository.Setup(pr => pr.Query(Filter)).Returns(listOfProducts);

            var result = handler.GetProductsByFilter(ProductHandlerTests.Filter).ToList();

            Assert.Equal(Filter, result[0].Make);
            Assert.Equal(Filter, result[1].Model);
            Assert.Equal(Filter, result[2].Description);
        }

        private Product CreateProduct(
            string make, string model, 
            string productId, string description, 
            double price)
        {
            return new Product
            {
                Model = model, 
                Description = description, 
                Make = make, 
                Price = price,
                ProductId = productId
            };
        }
    }
}
