using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphQLProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProduct _productService;

        public ProductsController(IProduct product)
        {
            _productService = product;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetProductById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            return _productService.AddProduct(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            return _productService.UpdateProduct(id, product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
