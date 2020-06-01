using System;
using System.Collections.Generic;
using System.Text;
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
            //arrange
            //create a product
            //create a sqlite in memory database
            //add product to in memory database
            //ensure our repo calls our in memory db
            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Make = "Nike",
                Model = "Nike Air Jordans Hoody",
                Description = "hoody, jumper, winter",
                Price = 80.00
            };
            
            var product2 = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Make = "Adidas",
                Model = "Adidas Hat",
                Description = "hat, headwear",
                Price = 10.00
            };

            var database = new InMemoryDatabase();
            database.Add(product);
            database.Add(product2);

            var databaseConnectionFactory = new Mock<IDatabaseConnectionFactory>();

            var pr = new ProductRepository(new SqlSettings(),databaseConnectionFactory.Object);
            databaseConnectionFactory.Setup(cf => cf.GetConnection(It.IsAny<string>())).Returns(database.Connection);
            //act
            //call our repo

            //assert
            //ensure the product returned is what we want
        }
    }
}
