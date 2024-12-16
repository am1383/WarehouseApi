using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Interfaces
{
    public interface IInventoryLogRepository 
    {
        Task<List<InventoryLog>> GetInventoryLogsAsync(int productId);
    }
} 