using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Romina.Api.Context;
using Romina.Api.Model;
using Romina.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Romina.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        // private readonly ProductContext _context;
        private readonly ICosmosDbService _cosmosDbService;
        public ProductController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }


        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _cosmosDbService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            try
            {
                var result = await _cosmosDbService.GetProduct(id);

                if (result == null)
                    return NotFound();

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product oProduct)
        {
            _cosmosDbService.AddProduct(oProduct);

            if(!ModelState.IsValid)
                return BadRequest();
            return Ok();

        }
    }
}