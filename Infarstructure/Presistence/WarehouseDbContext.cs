using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Models;

namespace WarehouseManagement.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(WarehouseDbContext).Assembly);
        }
    }
}
