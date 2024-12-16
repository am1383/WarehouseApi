using Microsoft.EntityFrameworkCore;
using Warehouse.Infarstructure.Interfaces;
using Warehouse.Infarstructure.Repositories;
using Warehouse.Infarstructure.Repository;
using WarehouseManagement.Data;

namespace Warehouse.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<WarehouseDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("ConnectionStrings"));
            });

            services.AddScoped(typeof(IGenericeRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryLogRepository, InventoryLogRepository>();

            return services;
        }
    }
}
