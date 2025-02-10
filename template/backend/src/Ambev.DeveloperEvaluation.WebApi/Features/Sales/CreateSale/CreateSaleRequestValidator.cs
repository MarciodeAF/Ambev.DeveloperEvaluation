
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.NumberSale).NotEmpty();
        RuleFor(sale => sale.CreatedSale).NotEmpty();
        //RuleFor(sale => sale.).SetValidator(new PasswordValidator());
        //RuleFor(sale => sale.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        //RuleFor(sale => sale.Status).NotEqual(UserStatus.Unknown);
        //RuleFor(sale => sale.Role).NotEqual(UserRole.None);
    }

}
