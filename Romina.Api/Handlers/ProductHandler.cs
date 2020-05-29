using Romina.Api.Models;
using Romina.Api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            filter = Regex.Replace(filter, @"\s+", " ");
            var splitFilter = filter.ToLower().Split(' ');

            var unsortedRelatedProducts = _productRepository.Query(filter);

            var sortedList = unsortedRelatedProducts
                .OrderByDescending(pr => splitFilter.Any(x => x == pr.Make.ToLower()))
                .ThenByDescending(pr => splitFilter.Any(y => y == pr.Model.ToLower()))
                .ThenByDescending(pr => splitFilter.Any(z => z == pr.Description.ToLower()));

            return sortedList;
        }
    }

    public interface IProductHandler
    {
        IEnumerable<Product> GetProductsByFilter(string filter);
    }

}
