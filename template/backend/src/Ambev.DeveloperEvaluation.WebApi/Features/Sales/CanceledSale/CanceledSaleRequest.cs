using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CanceledSale;

/// <summary>
/// Request model for canceled a sale by ID
/// </summary>
public class CanceledSaleRequest
{
    public Guid Id { get; set; }   

    public SaleStatus Status { get; set; }
}
