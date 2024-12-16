namespace WarehouseManagement.Models
{
    public class InventoryTransaction
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? OperationType { get; set; } 
        public string? Reason { get; set; }
        public DateTime Date { get; set; }
    }
}