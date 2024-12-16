using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Data;
using WarehouseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Infarstructure.Repository
{
    public class InventoryLogRepository : IInventoryLogRepository
    {
        private readonly WarehouseDbContext _context;

        public InventoryLogRepository(WarehouseDbContext context)
        {
            _context = context;
        }

       public async Task<InventoryLog> GetInventoryLogsAsync(int productId)
        {
            var inventoryLog = await _context.InventoryLogs
                .FirstOrDefaultAsync(i => i.ProductId == productId);

            if (inventoryLog == null)
            {
                throw new KeyNotFoundException($"InventoryLog for product ID {productId} not found.");
            }

            return inventoryLog;
        }
    }
}
