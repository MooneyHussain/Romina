using System;
using Romina.Api.Models;
using Moq;
using Romina.Api.Repositories;
using Romina.Api.Settings;
using Xunit;

namespace Romina.Api.AcceptanceTests
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void GetProductById_WhenProductExists_ThenReturnProduct()
        {
            var product = CreateProduct("Nike", "Nike Air Jordans Hoody", "hoody, jumper, winter", 80.00);
            var product2 = CreateProduct("Adidas", "Adidas Hat", "hat, headwear", 10.00);

            var database = new InMemoryDatabase();
            database.Add(product);
            database.Add(product2);

            var databaseConnectionFactory = new Mock<IDatabaseConnectionFactory>();

            var pr = new ProductRepository(new SqlSettings(),databaseConnectionFactory.Object);
            databaseConnectionFactory.Setup(cf => cf.GetConnection(It.IsAny<string>())).Returns(database.Connection);
            
            var result = pr.GetProductById(product.ProductId);

            Assert.Equal(product.ProductId,result.ProductId);
        }

        private static Product CreateProduct(string make, string model, string description, double price)
        {
            return new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Make = make,
                Model = model,
                Description = description,
                Price = price
            };
        }
    }
}
