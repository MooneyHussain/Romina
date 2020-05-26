using Microsoft.AspNetCore.Mvc;
using Romina.Api.Handlers;
using Romina.Api.Models;
using Romina.Api.Repositories;
using System.Collections.Generic;

namespace Romina.Api.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductHandler _productHandler;

        public ProductController(
            IProductRepository productRepository, 
            IProductHandler productHandler)
        {
            _productRepository = productRepository;
            _productHandler = productHandler;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            // TODO (at a later date): add GetProductById functionality into IProductHandler
            // this means we don't need to inject *both* IProductRepository and IProductHandler
            var product = _productRepository.GetProductById(id);

            if (product == null)
                return new NotFoundResult();

            return product;
        }

        [HttpGet] // accessed via api/product?filter=somevalue
        public IEnumerable<Product> GetByQuery([FromQuery] string filter) 
            // [FromQuery] is pretty cool ...  it sets up the endpoint to use a '?'
            // so in our scenario we have setup a parameter called 'filter' which we will use
            // so the final result is 'api/product?filter=somethingToSearchFor'
        {
            var relatedProducts = _productHandler
                .GetProductsByFilter(filter);

            return relatedProducts;
        }
    }
}