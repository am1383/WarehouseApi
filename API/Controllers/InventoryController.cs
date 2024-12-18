using Microsoft.AspNetCore.Mvc;
using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Models;

namespace Warehouse.Application.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        // POST: api/v1/<InventoryController>
        [HttpPost]
        public async Task<ActionResult> RegisterInventory(Inventory inventory)
        {
            await _inventoryRepository.Add(inventory);

            return Ok(inventory);
        }

        // GET: api/v1/<InventoryController>/{productId}
        [HttpGet("{productId}")]
        public async Task<ActionResult> GetInventoryDetails(int productId)
        {
            var inventories = await _inventoryRepository.GetInventoriesByProductIdAsync(productId);

            var balance = await _inventoryRepository.GetProductBalanceAsync(productId);

            return Ok(new
            {
                ProductId = productId,
                Balance = balance,
                Details = inventories
            });
        }

        // GET : api/v1/<InventoryController>
        [HttpGet]
        public async Task<ActionResult> GetAllInventory()
        {
            var inventory = await _inventoryRepository.GetAll();

            return Ok(inventory);
        }

        // PUT: api/v1/<InventoryController>
        [HttpPut]
        public async Task<ActionResult> UpdateInventoryDetails([FromBody] Inventory inventory)
        {
            await _inventoryRepository.Update(inventory);

            return Ok();
        }

        // DELETE: api/v1/<InventoryController>/{ProductId}
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveInventoryTransaction([FromBody] InventoryTransaction transaction, int productId)
        {
            await _inventoryRepository.AddInventoryTransactionAsync(transaction);

            await _inventoryRepository.Delete(productId);

            return Ok(new { Message = "Product removed from inventory", Transaction = transaction });
        }
    }
}