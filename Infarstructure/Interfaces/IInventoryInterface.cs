using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Interfaces
{
    public interface IInventoryInterface : IGenericeInterface<Inventory>
    {
        Task<IEnumerable<Inventory>> GetInventoriesByProductIdAsync(int productId);
        Task AddInventoryAsync(Inventory inventory);
        Task<int> GetProductBalanceAsync(int productId);
    }
}