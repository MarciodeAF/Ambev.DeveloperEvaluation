using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateUserRequest
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    /// <summary>
    ///  Initializes validation rules for UpdateUserRequest
    /// </summary>
    public UpdateSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");

        RuleFor(sale => sale.NumberSale).NotEmpty();
        RuleFor(sale => sale.Customer).NotEmpty().Length(3, 100);
        RuleFor(sale => sale.Agency).NotEmpty().Length(3, 100);

        RuleFor(sale => sale.Products)
           .NotEmpty()
           .WithMessage("The Products cannot be empty.")
           .Must(BeValidAmountMore20)
           .WithMessage("Maximum limit exceeded, allowed up to 20.")
           .Must(BeValidName)
           .WithMessage("Name cannot be empty.")
           .Must(BeValidDescription)
           .WithMessage("Description cannot be empty.")
           .Must(BeValidUnitPrice)
           .WithMessage("ValidUnit cannot be empty.");
    }

    private bool BeValidAmountMore20(List<Product> products)
    {
        bool bRes = true;

        foreach (var item in products)
        {
            if (item.Amount > 20)
            {
                bRes = false;
            }
        }

        return bRes;
    }

    private bool BeValidName(List<Product> products)
    {
        bool bRes = true;

        foreach (var item in products)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                bRes = false;
            }
        }

        return bRes;
    }

    private bool BeValidDescription(List<Product> products)
    {
        bool bRes = true;

        foreach (var item in products)
        {
            if (string.IsNullOrEmpty(item.Description))
            {
                bRes = false;
            }
        }

        return bRes;
    }

    private bool BeValidUnitPrice(List<Product> products)
    {
        bool bRes = true;

        foreach (var item in products)
        {
            if (item.UnitPrice == 0)
            {
                bRes = false;
            }
        }

        return bRes;
    }
}

