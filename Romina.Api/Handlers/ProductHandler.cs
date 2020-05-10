using Romina.Api.Models;
using Romina.Api.Repositories;
using System;
using System.Collections.Generic;

namespace Romina.Api.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductRepository _productRepository;

        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductsByFilter(string filter)
        {
            var unsortedRelatedProducts = _productRepository.Query(filter);

            // TODO: now we have our relevant products we want to order them correctly 
            // have a look at the tests for this class and give this a go 

            throw new NotImplementedException();
        }
    }

    public interface IProductHandler
    {
        IEnumerable<Product> GetProductsByFilter(string filter);
    }
}
