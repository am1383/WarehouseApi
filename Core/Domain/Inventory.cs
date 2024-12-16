using Warehouse.Domain;

namespace WarehouseManagement.Models
{
    public class Inventory : BaseDomainEntity
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public DateTime Timestamp { get; set; }
        public string? OperationType { get; set; }
        public string? Details { get; set; }
    }
}
