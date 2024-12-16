using WarehouseManagement.Data;
using WarehouseManagement.Models;
using Warehouse.Infarstructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Warehouse.Infarstructure.Repository;

namespace Warehouse.Infarstructure.Repositories
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        private readonly WarehouseDbContext _context;

        public InventoryRepository(WarehouseDbContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<Inventory>> GetInventoriesByProductIdAsync(int productId)
        {
            return await _context.Inventories
                .Where(i => i.ProductId == productId)
                .ToListAsync();
        }

        public async Task<int> GetProductBalanceAsync(int productId)
        {
            var totalIn = await _context.Inventories
                .Where(i => i.ProductId == productId && i.OperationType == "IN")
                .SumAsync(i => i.Quantity);

            var totalOut = await _context.Inventories
                .Where(i => i.ProductId == productId && i.OperationType == "OUT")
                .SumAsync(i => i.Quantity);

            return totalIn - totalOut;
        }
    }
}