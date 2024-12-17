using FluentValidation;
using Warehouse.Application.DTOs.Product;
using WarehouseManagement.Models;

namespace  Warehouse.Application.DTOs.CreateProduct.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Description).Null();
        }
    }
}