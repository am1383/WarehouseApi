using Warehouse.Infarstructure.Interfaces;
using Warehouse.Infarstructure.Repositories;
using Warehouse.Infarstructure.Repository;
using WarehouseManagement.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddScoped(typeof(IGenericeInterface<>), typeof(GenericRepository<WarehouseI>));
builder.Services.AddScoped<IWarehouseInterface, WarehouseRepository>();
builder.Services.AddScoped(typeof(IGenericeInterface<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IWarehouseInterface, WarehouseRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
