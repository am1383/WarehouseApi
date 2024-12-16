using Warehouse.Domain;

namespace WarehouseManagement.Models
{
    public class InventoryLog : BaseDomainEntity
    {
        public int ProductId { get; set; } 
        public Product Product { get; set; } 
        public int Quantity { get; set; } 
        public string OperationType { get; set; } 
        public string Reason { get; set; } 
        public DateTime OperationDate { get; set; } 
    }
}