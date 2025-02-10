using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CanceledSaleProduct;

/// <summary>
/// Request model for canceled a product at a sale by ID
/// </summary>
public class CanceledSaleProductRequest
{
    public Guid Id { get; set; }   

    public ProductStatus Status { get; set; }

    public Guid SaleId { get; set; }
}
