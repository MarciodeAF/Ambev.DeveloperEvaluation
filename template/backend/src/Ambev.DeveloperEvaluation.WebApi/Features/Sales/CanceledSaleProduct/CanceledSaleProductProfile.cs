

using Ambev.DeveloperEvaluation.Application.Sales.CanceledSaleProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CanceledSaleProduct;

/// <summary>
/// Profile for mapping CanceledSaleProduct feature requests to commands
/// </summary>
public class CanceledSaleProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CanceledSaleProduct feature
    /// </summary>
    public CanceledSaleProductProfile()
    {
        CreateMap<CanceledSaleProductRequest, CanceledSaleProductCommand>();
        CreateMap<CanceledSaleProductResult, CanceledSaleProductResponse>();
    }
}
