using Warehouse.Domain;

namespace WarehouseManagement.Models
{
    public class Product : BaseDomain
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
