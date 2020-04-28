using Microsoft.AspNetCore.Mvc;
using Romina.Api.Models;
using Romina.Api.Repositories;

namespace Romina.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return new NotFoundResult();
            }

            return product;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}