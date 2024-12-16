using FluentValidation;
using WarehouseManagement.Models;

namespace  Warehouse.Application.DTOs.CreateProduct.Validators
{
    public class RegisterInventoryValidator : AbstractValidator<Inventory>
    {
        public RegisterInventoryValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Quantity).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(1).WithMessage("{PropertyName} must be at least 1");
        }
    }
}