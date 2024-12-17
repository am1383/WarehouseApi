using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Data;
using WarehouseManagement.Models;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Excecptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Warehouse.Infarstructure.Repository
{
    public class InventoryLogRepository : IInventoryLogRepository
    {
        private readonly WarehouseDbContext _context;
        public InventoryLogRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<int> CalcTotalInInventory(int productId)
        {
            return await _context.InventoryLogs
                .Where(i => i.ProductId == productId && i.OperationType == "IN")
                .SumAsync(i => i.Quantity);
        }

        public async Task<int> CalcTotalOutInventory(int productId)
        {
            return await _context.InventoryLogs
                .Where(i => i.ProductId == productId && i.OperationType == "OUT")
                .SumAsync(i => i.Quantity);
        }

       public async Task<int> GetInventoryLogsAsync(int productId)
        {
            var inventoryLog = await _context.InventoryLogs
                .FirstOrDefaultAsync(i => i.ProductId == productId);

            if (inventoryLog == null)
            {
                throw new NotFoundExceptions(productId, "product");
            }

            var totalIn = await CalcTotalInInventory(productId);

            var totalOut = await CalcTotalOutInventory(productId);

            var total = totalIn - totalOut;

            return total;
                
        }
    }
}
