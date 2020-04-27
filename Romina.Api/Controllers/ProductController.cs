using Microsoft.AspNetCore.Mvc;
using Romina.Api.Models;
using System;

namespace Romina.Api.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }
    }
}