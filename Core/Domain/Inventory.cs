namespace WarehouseManagement.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }
        public WarehouseI? Warehouse { get; set; }
    }
}
