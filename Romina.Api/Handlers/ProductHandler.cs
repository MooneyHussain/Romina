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

            var unsortedRelatedProducts = _productRepository.Query(filter);

            var sortedList = new List<Product>();

            foreach (var product in unsortedRelatedProducts)
            {
                sortedList.AddRange(from param in splitFilter 
                    where product.Make.ToLower().Contains(param) select product);
            }

            foreach (var product in unsortedRelatedProducts.Where(product => !IsDuplicate(product, sortedList)))
            {
                sortedList.AddRange(from param in splitFilter 
                    where product.Model.ToLower().Contains(param) select product);
            }

            foreach (var product in unsortedRelatedProducts.Where(product => !IsDuplicate(product, sortedList)))
            {
                sortedList.AddRange(from param in splitFilter 
                    where product.Description.ToLower().Contains(param) select product);
            }

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
