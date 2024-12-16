using FluentValidation;
using WarehouseManagement.Models;

namespace  Warehouse.Application.DTOs.CreateProduct.Validators
{
    public class CreateProductValidator : AbstractValidator<Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Description).Null();
        }
    }
}