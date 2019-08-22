using Microsoft.Azure.Cosmos;
using Romina.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Romina.Api.Services
{
    public interface ICosmosDbService
    {
        Task AddProduct(Product oProduct);
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProducts();

    }
}