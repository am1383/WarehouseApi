namespace Warehouse.Application.DTOs.Inventory
{
    public interface IRegisterInventoryDTO
    {
        public int ProductId { get; set; } 
        public int Quantity { get; set; } 
        public DateTime LastUpdated { get; set; }
    }
}