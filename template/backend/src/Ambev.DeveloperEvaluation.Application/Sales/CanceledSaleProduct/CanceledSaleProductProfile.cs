using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CanceledSaleProduct;

public class CanceledSaleProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CanceledSaleProduct operation
    /// </summary>
    public CanceledSaleProductProfile()
    {
        CreateMap<CanceledSaleProductCommand, Sale>();
        CreateMap<Sale, CanceledSaleProductResult>();
    }
}
