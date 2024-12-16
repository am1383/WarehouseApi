using WarehouseManagement.Data;
using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Repositories
{
    public class InventoryRepository : IInventoryInterface<Inventory>
    {
        private readonly WarehouseDbContext _context;

        public InventoryRepository(WarehouseDbContext context)
        {
            _context = context;
        }
    }
}