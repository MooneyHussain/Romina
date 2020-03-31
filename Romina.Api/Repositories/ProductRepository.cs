using System;
using Romina.Api.Models;

namespace Romina.Api.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public Product GetProductById(string id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProductRepository
    {
        Product GetProductById(string id);
    }
}
