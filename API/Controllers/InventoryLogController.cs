using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Warehouse.Infarstructure.Interfaces;

namespace Warehouse.Application.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InventoryLogController : ControllerBase
    {
        private readonly IInventoryLogRepository _inventoryLogRepository;

        public InventoryLogController(IInventoryLogRepository inventoryLogRepository)
        {
            _inventoryLogRepository = inventoryLogRepository;
        }

        // GET: api/v1/Inventory/{productId}/logs
        [HttpGet("{productId}/logs")]
        public async Task<ActionResult> GetInventoryLogs(int productId)
        {
            var logs = await _inventoryLogRepository.GetInventoryLogsAsync(productId);
            
            return Ok(new {
                productId,
                logs
            });
        }
    }
}