

using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{

    public long NumberSale { get; set; }

    public DateTime CreatedSale { get; set; }

    public string Customer { get; set; } = string.Empty;

    public Decimal TotalValue { get; set; }

    public string Agency { get; set; } = string.Empty;

    public DateTime? UpdatedAt { get; set; }

    public List<Product>? Products { get; set; } = new List<Product> { };


    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

}
