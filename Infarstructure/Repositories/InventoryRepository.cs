using WarehouseManagement.Data;
using WarehouseManagement.Models;
using Warehouse.Infarstructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Warehouse.Infarstructure.Repository;
using Warehouse.Application.Excecptions;

namespace Warehouse.Infarstructure.Repositories
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        private readonly WarehouseDbContext _context;

        public InventoryRepository(WarehouseDbContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<Inventory>> GetInventoriesByProductIdAsync(int productId)
        {
            return await _context.Inventories
                .Where(i => i.ProductId == productId)
                .ToListAsync();
        }

        public async Task<int> CalcTotalInInventory(int productId)
        {
            return await _context.InventoryLogs
                .Where(i => i.ProductId == productId && i.OperationType == "IN")
                .SumAsync(i => i.Quantity);
        }

        public async Task<int> CalcTotalOutInventory(int productId)
        {
            return await _context.InventoryLogs
                .Where(i => i.ProductId == productId && i.OperationType == "OUT")
                .SumAsync(i => i.Quantity);
        }

        public async Task<int> GetProductBalanceAsync(int productId)
        {
            var totalIn = await CalcTotalInInventory(productId);
            var totalOut = await CalcTotalOutInventory(productId);

            return totalIn - totalOut;
        }

        public async Task<Inventory> GetInventoryAsync(int productId)
        {
            var inventory = await _context.Inventories
                .FirstOrDefaultAsync(i => i.ProductId == productId);

            if (inventory == null)
            {
                 throw new NotFoundExceptions(productId);
            }

            return inventory;   
        }

        public async Task AddInventoryTransactionAsync(InventoryTransaction transaction)
        {
            var inventoryLog = new InventoryLog
            {
                ProductId = transaction.ProductId,
                Quantity = transaction.Quantity,
                OperationType = transaction.OperationType,
                OperationDate = transaction.Date
            };

            await _context.InventoryLogs.AddAsync(inventoryLog);

            var inventory = await GetInventoryAsync(transaction.ProductId);
            if (inventory != null)
            {
                inventory.Quantity += (transaction.OperationType == "IN" ? transaction.Quantity : -transaction.Quantity);
                inventory.LastUpdated = transaction.Date;
            }
            else
            {
                _context.Inventories.Add(new Inventory
                {
                    ProductId = transaction.ProductId,
                    Quantity = transaction.Quantity,
                    LastUpdated = transaction.Date
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(int productId, int quantityChange)
        {
            var inventory = await GetInventoryAsync(productId);
            
            inventory.Quantity += quantityChange;
            await _context.SaveChangesAsync();
        }

        public Task checkValidationAddInventoryTransaction(InventoryTransaction transaction, string OperationType)
        {
            if (transaction.Quantity <= 0) throw new BadRequestExceptions("Quantity must be greater than zero.");

            if (transaction.OperationType != OperationType) throw new BadRequestExceptions("Invalid operation type.");

            return Task.CompletedTask;         
        }
    }
}