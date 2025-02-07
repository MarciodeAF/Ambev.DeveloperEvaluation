using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Request model for updating a user by ID
/// </summary>
public class UpdateSaleRequest
{
    public Guid Id { get; set; }

    public long NumberSale { get; set; }

    public DateTime CreatedSale { get; set; }

    public string Customer { get; set; } = string.Empty;

    public Decimal TotalValue { get; set; }

    public string Agency { get; set; } = string.Empty;

    public DateTime? UpdatedAt { get; set; }

    public List<Product> Products { get; set; }
}
