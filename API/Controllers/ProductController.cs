using Microsoft.AspNetCore.Mvc;
using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Models;

namespace Warehouse.Application.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/v1/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();

            return Ok(products);
        }

        // POST: api/v1/<ProductController>/{productId}
        [HttpPost("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var product = await _productRepository.Get(productId);

            return Ok(product);
        }

        // POST: api/v1/<ProductController>
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            await _productRepository.Add(product);

            return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
        }

        // DELETE: api/v1/<ProductController>/{ProductId}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Product product)
        {
            await _productRepository.Delete(product);

            return Ok();
        }

        // PUT: api/v1/<ProductController>
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            await _productRepository.Update(product);

            return Ok();
        }
    }
}