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
                foreach (var param in splitFilter)
                {
                    if (product.Make.ToLower().Contains(param))
                    {
                        if (!IsDuplicate(product, sortedList))
                        {
                            sortedList.Add(product);
                        }
                    }
                }
            }

            foreach (var product in unsortedRelatedProducts)
            {
                foreach (var param in splitFilter)
                {
                    if (product.Model.ToLower().Contains(param))
                    {
                        if (!IsDuplicate(product, sortedList))
                        {
                            sortedList.Add(product);
                        }
                    }
                }
            }

            foreach (var product in unsortedRelatedProducts)
            {
                foreach (var param in splitFilter)
                {
                    if (product.Description.ToLower().Contains(param))
                    {
                        if (!IsDuplicate(product, sortedList))
                        {
                            sortedList.Add(product);
                        }
                    }
                }
            }
            return sortedList;
        }

        public bool IsDuplicate(Product newProduct, List<Product> listofProd)
        {
            foreach (var product in listofProd)
            {
                if (product.Equals(newProduct))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public interface IProductHandler
    {
        IEnumerable<Product> GetProductsByFilter(string filter);
    }
}
