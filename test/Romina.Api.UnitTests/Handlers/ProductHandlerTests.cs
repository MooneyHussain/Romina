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

        [Fact]
        public void GetProductsByFilter_WhenProductsPartlyMatchFilter_ReturnProductsInOrder()
        {
            var nikeHoodieFilter = "Nike Hoodie";

            var productOne = CreateProduct(
                "Nike", 
                "Hoodie", 
                "1", 
                "Nike Club zip up hoodie in grey", 
                45);

            var productTwo = CreateProduct(
                "Puma",
                "Hoodie",
                "2",
                "Puma Hooded Jacket",
                30);

            var productThree = CreateProduct(
                "Matalan",
                "Jacket",
                "3",
                "Grey jacket with hood, sometimes referred to as a hoodie",
                8);

            _productRepository.Setup(pr => pr.Query(It.IsAny<string>()))
                .Returns(new List<Product> 
                { 
                    productThree, productTwo, productOne 
                });

            var handler = new ProductHandler(_productRepository.Object);
            
            var result = handler.GetProductsByFilter(nikeHoodieFilter);

            Assert.Equal(3, result.Count());
            Assert.Equal(productOne.ProductId, result.ElementAt(0).ProductId);
            Assert.Equal(productTwo.ProductId, result.ElementAt(1).ProductId);
            Assert.Equal(productThree.ProductId, result.ElementAt(2).ProductId);
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
