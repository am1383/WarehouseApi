using AutoMapper;
using Warehouse.Application.DTOs.CreateProduct.Validators;
using Warehouse.Application.DTOs.Inventory;
using Warehouse.Application.DTOs.Product;
using WarehouseManagement.Models;

namespace Warehouse.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
                CreateMap<Product, CreateProductDTO>().ReverseMap();
            #endregion

            #region Inventory
                CreateMap<Inventory, RegisterInventoryDTO>().ReverseMap();
            #endregion
        }
    }
}