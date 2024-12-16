using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Interfaces
{
    public interface IInventoryLogRepository 
    {
        Task<InventoryLog> GetInventoryLogsAsync(int productId);
    }
} 