
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        //RuleFor(sale => sale.Email).SetValidator(new EmailValidator());
        //RuleFor(sale => sale.Username).NotEmpty().Length(3, 50);
        //RuleFor(sale => sale.Password).SetValidator(new PasswordValidator());
        //RuleFor(sale => sale.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        //RuleFor(sale => sale.Status).NotEqual(UserStatus.Unknown);
        //RuleFor(sale => sale.Role).NotEqual(UserRole.None);
    }

}
