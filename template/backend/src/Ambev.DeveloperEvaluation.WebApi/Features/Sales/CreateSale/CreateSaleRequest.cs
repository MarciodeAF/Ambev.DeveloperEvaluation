using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{

    public long NumberSale { get; set; }

   // public DateTime CreatedSale { get; set; }

    public string Customer { get; set; } = string.Empty;

 //   public Decimal TotalValue { get; set; }

    public string Agency { get; set; } = string.Empty;

  //  public DateTime? UpdatedAt { get; set; }

    public List<Product>? Products { get; set; } = new List<Product> { };

    //  public SaleStatus Status { get; set; }



    
}

