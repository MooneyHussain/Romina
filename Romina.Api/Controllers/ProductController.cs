using Microsoft.AspNetCore.Mvc;
using System;

namespace Romina.Api.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}