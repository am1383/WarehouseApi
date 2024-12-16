using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Data;
using WarehouseManagement.Models;
using Warehouse.Infarstructure.Repository;

namespace Warehouse.Infarstructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly WarehouseDbContext _context;

        public ProductRepository(WarehouseDbContext context)
            :base(context)
        {
            _context = context;
        }
    }
}