
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product
{
    public Product() { }

    public Guid Id { get; set; }

    public string Name { get; set; }    

    public string Description { get; set; }

    public decimal UnitPrice { get; set; }

    public int Discount { get; set; }  

    public virtual Guid SaleId { get; set; }

    public ProductStatus Status { get; set; }
}
