using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Interfaces
{
    public interface IInventoryRepository : IGenericeRepository<Inventory>
    {
        Task<List<Inventory>> GetInventoriesByProductIdAsync(int productId);
        Task<int> GetProductBalanceAsync(int productId);
    }
}