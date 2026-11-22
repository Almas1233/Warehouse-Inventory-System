using FluentValidation;
using FluentValidation.Results;
using WarehouseInventorySystem.Application.Handlers.Features.Products.CreateProduct;
using WarehouseInventorySystem.Contracts.Enums;
using ValidationException = WarehouseInventorySystem.Application.Handlers.Exceptions.ValidationException;

namespace WarehouseInventorySystem.Application.Handlers.Features.Products.Validations;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name cannot be empty.")
            .WithState(_ => new ValidationErrorInfo(
                "Product name is required.",
                ResponseCode.InvalidInput,
                "Product name cannot be empty.",
                400
            ));

        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("Sku cannot be empty.")
            .WithState(_ => new ValidationErrorInfo(
                "Sku is required.",
                ResponseCode.InvalidInput,
                "Sku cannot be empty.",
                400
            ));

        RuleFor(x => x.Sku)
            .Length(8)
            .WithMessage("Sku must contain exactly 8 characters.")
            .WithState(_ => new ValidationErrorInfo( 
                "Invalid Sku format.",
                ResponseCode.InvalidInput,
                "Sku must contain exactly 8 characters.",
                400
            ));
    }

    protected override void RaiseValidationException(
        ValidationContext<CreateProductRequest> context,
        ValidationResult result)
    {
        var error = (ValidationErrorInfo)result.Errors[0].CustomState!;

        throw new ValidationException(
            error.Message,
            error.Code,
            error.Description,
            error.StatusCode
        );
    }
}