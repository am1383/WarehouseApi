using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Excecptions;
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

        public async Task<T?> Get(int productId)
        {
            var product = await FindOrFailAsync(productId);
            
            return product;
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

        public async Task Delete(int id)
        {
            var entity = await FindOrFailAsync(id);
 if (entity == null)
            {
                throw new NotFoundExceptions(id);
            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> FindOrFailAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            return entity;
        }
    }
}