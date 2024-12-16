using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Interfaces
{
    public interface IInventoryRepository : IGenericeRepository<Inventory>
    {
        Task<List<Inventory>> GetInventoriesByProductIdAsync(int productId);

        Task<int> GetProductBalanceAsync(int productId);

        Task<Inventory> GetInventoryAsync(int productId);

        Task<List<InventoryLog>> GetInventoryLogsAsync(int productId);

        Task AddInventoryTransactionAsync(InventoryTransaction transaction);

        Task UpdateInventoryAsync(int productId, int quantityChange);

        Task checkValidationAddInventoryTransaction(InventoryTransaction transaction, string OperationType);
    }
}