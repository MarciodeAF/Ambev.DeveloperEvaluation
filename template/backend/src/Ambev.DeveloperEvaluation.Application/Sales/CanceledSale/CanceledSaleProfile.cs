using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CanceledSale;

public class CanceledSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CanceledSale operation
    /// </summary>
    public CanceledSaleProfile()
    {
        CreateMap<CanceledSaleCommand, Sale>();
        CreateMap<Sale, CanceledSaleResult>();
    }
}
