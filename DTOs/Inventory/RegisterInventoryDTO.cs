using Warehouse.Application.DTO.Common;

namespace Warehouse.Application.DTOs.Inventory
{
    public class RegisterInventoryDTO : BaseDTO, IRegisterInventoryDTO
    {
        public int ProductId { get; set; } 
        public int Quantity { get; set; } 
        public DateTime LastUpdated { get; set; }
    }
}