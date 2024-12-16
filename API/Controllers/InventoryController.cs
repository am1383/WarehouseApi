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

        // POST: api/v1/<InventoryController>/register
        [HttpPost("register")]
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

        // POST: api/v1/<InventoryController>
        [HttpPost]
        public async Task<ActionResult> AddInventoryTransaction([FromBody] InventoryTransaction transaction)
        {
            await _inventoryRepository.checkValidationAddInventoryTransaction(transaction, "IN");

            await _inventoryRepository.AddInventoryTransactionAsync(transaction);

            return Ok(new { Message = "Product added to inventory", Transaction = transaction });
        }

        // POST: api/v1/Inventory/remove
        [HttpDelete("remove")]
        public async Task<ActionResult> RemoveInventoryTransaction([FromBody] InventoryTransaction transaction)
        {
            await _inventoryRepository.checkValidationAddInventoryTransaction(transaction, "OUT");

            await _inventoryRepository.AddInventoryTransactionAsync(transaction);

            return Ok(new { Message = "Product removed from inventory", Transaction = transaction });
        }
    }
}