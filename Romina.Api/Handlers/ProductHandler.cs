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
            var splitFilter = filter.ToLower().Split(' ');
            splitFilter = splitFilter.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToArray();

            var unsortedRelatedProducts = _productRepository.Query(filter);

            var sortedList = unsortedRelatedProducts
                .OrderByDescending(pr => splitFilter.Any(x => x == pr.Make.ToLower()))
                .ThenByDescending(pr => splitFilter.Any(y => y == pr.Model.ToLower()))
                .ThenByDescending(pr => splitFilter.Any(z => z == pr.Description.ToLower()));

            return sortedList;
        }

        public bool IsDuplicate(Product newProduct, List<Product> listofProd)
        {
            return Enumerable.Contains(listofProd, newProduct);
        }
    }

    public interface IProductHandler
    {
        IEnumerable<Product> GetProductsByFilter(string filter);
    }

}
