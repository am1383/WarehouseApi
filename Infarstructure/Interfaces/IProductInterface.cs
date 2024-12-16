using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Interfaces
{
    public interface IProductRepository : IGenericeInterface<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }   
}