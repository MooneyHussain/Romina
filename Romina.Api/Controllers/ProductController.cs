using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Romina.Api.Models;
using Romina.Api.Repositories;

namespace Romina.Api.Controllers
{
    [Route("api/product")]
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

        [HttpGet("{make}")]
        //should this method always be of type actionresult? Or can I have it return List<Product>
        public ActionResult<Product> GetByMake(string make)
        {
            var product = _productRepository.GetProductByMake(make);
            if (product == null)
            {
                return new NotFoundResult();
            }

            return product;
        }

        [HttpGet("{model}")]
        public ActionResult<Product> GetByModel(string model)
        {
            var product = _productRepository.GetProductByModel(model);
            if (product == null)
            {
                return new NotFoundResult();
            }

            return product;
        }
    }
}