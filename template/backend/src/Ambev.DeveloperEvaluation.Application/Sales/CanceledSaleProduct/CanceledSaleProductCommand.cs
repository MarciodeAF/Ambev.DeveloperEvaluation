using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CanceledSaleProduct;

public class CanceledSaleProductCommand : IRequest<CanceledSaleProductResult>
{
    public Guid Id { get; set; }

    public ProductStatus Status { get; set; }

    public Guid SaleId { get; set; }

    public CanceledSaleProductCommand(Guid id, ProductStatus status, Guid saleId)
    {
        Id = id;
        Status = status;
        SaleId = saleId;
    }
}
