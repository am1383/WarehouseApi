using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Data;
using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Repositories
{
    public class ProductRepository : IProductInterface<Product>
    {
        private readonly WarehouseDbContext _context;

        public ProductRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        
    }
}