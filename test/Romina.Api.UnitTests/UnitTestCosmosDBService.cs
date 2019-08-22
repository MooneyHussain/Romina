using Microsoft.Azure.Cosmos;
using NSubstitute;
using Romina.Api.Model;
using Romina.Api.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Romina.Api.UnitTests
{
    public class UnitTestCosmosDBService
    {
        private CosmosClient cosmosClient;
        private Container container;
        private CosmosDbService cosmosService;

        public UnitTestCosmosDBService()
        {
            cosmosClient = Substitute.For<CosmosClient>();
            container = Substitute.For<Container>();

            cosmosClient.GetContainer(Arg.Any<string>(), Arg.Any<string>()).Returns(container);
            cosmosService = new CosmosDbService(cosmosClient, "", "");
        }

        [Fact]
        public async Task Get_WhenProductExistThenReturnProductAsync()
        {
            var product = new Product() { ProductId = "abc", Make = "Adidas", Model = "model", Price = 10.00, Description = "" };
            var itemResponse = Substitute.For<ItemResponse<Product>>();
            itemResponse.Resource.Returns(product);

            container.ReadItemAsync<Product>(Arg.Any<string>(), Arg.Any<PartitionKey>()).Returns(itemResponse);
            var result = await cosmosService.GetProduct("abc");

            Assert.Same(product, result);
        }

        [Fact]
        public async Task Get_WhenProductDoesNotExistThenReturnExceptionMessageAsync()
        {        
            container.When(x => x.ReadItemAsync<Product>(Arg.Any<string>(), Arg.Any<PartitionKey>()))
                      .Do(x => throw new Exception());

            await Assert.ThrowsAsync<Exception>(async () => await cosmosService.GetProduct("abc"));
        }

        [Fact]
        public async Task Get_whenProductDoesNotExistThenReturnNull()
        { 
           container.When(x => x.ReadItemAsync<Product>(Arg.Any<string>(), Arg.Any<PartitionKey>()))
                     .Do(x => throw new CosmosException("abc", HttpStatusCode.NotFound, 1, "",10.2));

            var result = await cosmosService.GetProduct("123");            
            Assert.Null(result);
        }



       

     
    }
}
