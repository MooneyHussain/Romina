using System;
using Romina.Api.Models;

namespace Romina.Api.Repositories
{
    public class ProductRepository
    {
        public Product GetProductById(string id)
        {
            return new Product 
                {
                    Description = " hat", 
                    Make = "nike", 
                    Model = "sport", 
                    Price = 10.0, 
                    ProductId = "111"

                };
        }
    }
}
