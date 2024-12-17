namespace Warehouse.Application.DTOs.Product
{
    public interface ICreateProductDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } 
        public DateTime Createdat { get; set; } 
    }
}