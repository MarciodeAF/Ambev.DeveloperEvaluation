using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CanceledSaleProduct;

/// <summary>
/// API response model for CanceledSaleProduct operation
/// </summary>
public class CanceledSaleProductResponse
{
    public Guid Id { get; set; }

    public long NumberSale { get; set; }

    public DateTime CreatedSale { get; set; }

    public string Customer { get; set; } = string.Empty;

    public Decimal TotalValue { get; set; }

    public string Agency { get; set; } = string.Empty;

    public DateTime? UpdatedAt { get; set; }

    public List<Product> Products { get; set; }

    public SaleStatus Status { get; set; }
}
