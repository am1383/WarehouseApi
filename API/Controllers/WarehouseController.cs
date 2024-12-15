using Microsoft.AspNetCore.Mvc;
using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Models;

namespace Warehouse.Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseInterface _warehouseRepository;

        public WarehouseController(IWarehouseInterface warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _warehouseRepository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WarehouseI product)
        {
            await _warehouseRepository.Add(product);
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
        }
    }
}
