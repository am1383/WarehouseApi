using Microsoft.EntityFrameworkCore;
using Warehouse.Infarstructure.Interfaces;
using WarehouseManagement.Data;

namespace Warehouse.Infarstructure.Repository
{
    public class GenericRepository<T> : IGenericeRepository<T> where T : class
    {
        private readonly WarehouseDbContext _context;

        public GenericRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}