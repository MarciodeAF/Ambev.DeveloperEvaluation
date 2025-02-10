using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.Products)
            .NotEmpty()
            .WithMessage("The Products cannot be empty.")
            .Must(BeValidAmountMore20)
            .WithMessage("Maximum limit exceeded, allowed up to 20.");
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
}
