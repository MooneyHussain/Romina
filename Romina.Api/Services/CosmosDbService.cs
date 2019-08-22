using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Romina.Api.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

namespace Romina.Api.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(CosmosClient dbClient, string dataBaseName, string containerName)
        {
            this._container = dbClient.GetContainer(dataBaseName, containerName);

        }

        public async Task AddProduct(Product oProduct)
        {
            try
            {
                var response = await _container.CreateItemAsync(oProduct);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetProduct(string id)
        {
            try
            {
                ItemResponse<Product> response = await this._container.ReadItemAsync<Product>(id, new PartitionKey(id));

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
                    
         }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var query = this._container.GetItemQueryIterator<Product>();
            List<Product> result = new List<Product>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response.ToList());
                
            }
            return result;
        }

    }
}
