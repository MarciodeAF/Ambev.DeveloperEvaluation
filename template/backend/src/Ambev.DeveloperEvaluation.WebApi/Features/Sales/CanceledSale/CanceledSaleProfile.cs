
using Ambev.DeveloperEvaluation.Application.Sales.CanceledSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CanceledSale;

/// <summary>
/// Profile for mapping UpdateUser feature requests to commands
/// </summary>
public class CanceledSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateUser feature
    /// </summary>
    public CanceledSaleProfile()
    {
        CreateMap<CanceledSaleRequest, CanceledSaleCommand>();
        CreateMap<CanceledSaleResult,CanceledSaleResponse>();
    }
}
