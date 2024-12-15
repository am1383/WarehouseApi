using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Data;
using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Models;

namespace Warehouse.Infarstructure.Repositories
{
    public class WarehouseRepository : IWarehouseInterface
    {
        private readonly WarehouseDbContext _context;

        public WarehouseRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<WarehouseI>> GetAll()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task Add(WarehouseI warehouse)
        {
            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task Update(WarehouseI warehouse)
        {
            _context.Warehouses.Update(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(WarehouseI entity)
        {
            _context.Warehouses.Remove(entity);
            await _context.SaveChangesAsync();   
        }
    }
}
