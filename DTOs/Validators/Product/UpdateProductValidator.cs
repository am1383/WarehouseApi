using FluentValidation;
using WarehouseManagement.Models;

namespace  Warehouse.Application.DTOs.CreateProduct.Validators
{
    public class UpdateProductValidator : AbstractValidator<Product>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Name).Null();

            RuleFor(p => p.Description).Null();
        }
    }
}