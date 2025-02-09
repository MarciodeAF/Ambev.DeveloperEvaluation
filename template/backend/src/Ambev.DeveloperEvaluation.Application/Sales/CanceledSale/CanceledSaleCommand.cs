using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CanceledSale;

public class CanceledSaleCommand : IRequest<CanceledSaleResult>
{
    public Guid Id { get; set; }  

    public SaleStatus Status { get; set; }

    public CanceledSaleCommand(Guid id, SaleStatus status)
    {
        Id = id;
        Status = status;
    }
}
