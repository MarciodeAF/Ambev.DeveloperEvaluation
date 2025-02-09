using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CanceledSale;

public class CanceledSaleCommandValidator : AbstractValidator<CanceledSaleCommand>
{
    public CanceledSaleCommandValidator()
    {
        //RuleFor(sale => sale.Email).SetValidator(new EmailValidator());
        //RuleFor(sale => sale.Username).NotEmpty().Length(3, 50);
        //RuleFor(sale => sale.Password).SetValidator(new PasswordValidator());
        //RuleFor(sale => sale.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        //RuleFor(sale => sale.Status).NotEqual(UserStatus.Unknown);
        //RuleFor(sale => sale.Role).NotEqual(UserRole.None);
    }
}
