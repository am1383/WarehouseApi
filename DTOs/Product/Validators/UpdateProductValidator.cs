using FluentValidation;
using Warehouse.Application.DTOs.Product;
using WarehouseManagement.Models;

namespace  Warehouse.Application.DTOs.CreateProduct.Validators
{
    public class UpdateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Name).Null();

            RuleFor(p => p.Description).Null();
        }
    }
}