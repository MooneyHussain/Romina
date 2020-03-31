using Microsoft.AspNetCore.Mvc;
using System;
using Romina.Api.Models;
using Romina.Api.Repositories;

namespace Romina.Api.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            var repository = new ProductRepository();
            var product = repository.GetProductById(id);
            return product;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }

    
}