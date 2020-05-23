using Romina.Api.Models;
using Romina.Api.Repositories;
using System.Collections.Generic;
using System.Linq;

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

            var sortedList = new List<Product>();

            sortedList.AddRange(unsortedRelatedProducts.Where(product => product.Make == filter));
            sortedList.AddRange(unsortedRelatedProducts.Where(product => product.Model == filter));
            sortedList.AddRange(unsortedRelatedProducts.Where(product => product.Description == filter));

            return sortedList;
        }
    }

    public interface IProductHandler
    {
        IEnumerable<Product> GetProductsByFilter(string filter);
    }
}
