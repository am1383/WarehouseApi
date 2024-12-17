using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Interfaces
{
    public interface IInventoryLogRepository 
    {
        Task<int> GetInventoryLogsAsync(int productId);
    }
} 