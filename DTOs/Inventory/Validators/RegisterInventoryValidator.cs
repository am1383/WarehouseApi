using FluentValidation;
using Warehouse.Application.DTOs.Inventory;
using Warehouse.Application.DTOs.Product;

namespace Warehouse.Application.DTOs.CreateProduct.Validators
{
    public class RegisterInventoryValidator : AbstractValidator<RegisterInventoryDTO>
    {
        public RegisterInventoryValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Quantity).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1");
        }
    }
}
