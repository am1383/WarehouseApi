using System.Security.AccessControl;
using Warehouse.Infarstructure.Interfaces;
using Warehouse.Infarstructure.Repositories;
using Warehouse.Infarstructure.Repository;
using WarehouseManagement.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Add controllers support
builder.Services.AddEndpointsApiExplorer(); // Add API Explorer for Swagger

builder.Services.AddScoped(typeof(IGenericeInterface<>), typeof(GenericRepository<WarehouseI>));
builder.Services.AddScoped<IWarehouseInterface, WarehouseRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Map controllers

app.Run();
