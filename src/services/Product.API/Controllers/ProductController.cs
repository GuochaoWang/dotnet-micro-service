using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MicroServiceStructure.Service.Product.API.Model;

namespace MicroServiceStructure.Service.Product.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET /id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Model.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _repository.GetProductAsync(id);
            return Ok(product);
        }

        // POST /value
        [HttpPost]
        [ProducesResponseType(typeof(Model.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]Model.Product value)
        {
            var product = await _repository.UpdateProductAsync(value);
            return Ok(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.DeleteProductAsync(id);
        }
    }
}