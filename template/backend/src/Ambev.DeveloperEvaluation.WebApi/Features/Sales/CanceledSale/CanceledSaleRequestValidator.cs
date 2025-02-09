using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CanceledSale;

/// <summary>
/// Validator for UpdateUserRequest
/// </summary>
public class CanceledSaleRequestValidator : AbstractValidator<CanceledSaleRequest>
{
    /// <summary>
    ///  Initializes validation rules for UpdateUserRequest
    /// </summary>
    public CanceledSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
