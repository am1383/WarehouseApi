using Warehouse.Domain;

namespace WarehouseManagement.Models
{
    public class Product : BaseDomainEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } 
        public DateTime Createdat { get; set; } 
    }
}
