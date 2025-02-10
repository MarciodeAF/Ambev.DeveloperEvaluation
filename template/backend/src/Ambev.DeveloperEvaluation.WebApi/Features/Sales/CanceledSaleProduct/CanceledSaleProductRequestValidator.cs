using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CanceledSaleProduct;

/// <summary>
/// Validator for CanceledSaleProductRequest
/// </summary>
public class CanceledSaleProductRequestValidator : AbstractValidator<CanceledSaleProductRequest>
{
    /// <summary>
    ///  Initializes validation rules for CanceledSaleProductRequest
    /// </summary>
    public CanceledSaleProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
