using Warehouse.Application.DTO.Common;

namespace Warehouse.Application.DTOs.Product
{
    public class CreateProductDTO : BaseDTO, ICreateProductDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } 
        public DateTime Createdat { get; set; } 
    }
}