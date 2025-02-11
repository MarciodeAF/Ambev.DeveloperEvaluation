
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;
using System.Net.NetworkInformation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;       
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = _mapper.Map<Sale>(command);

        sale.Status = Domain.Enums.SaleStatus.Active;
        sale.CreatedSale = DateTime.UtcNow;       

        foreach (var item in sale.Products)
        {  
            if (item.Amount > 4 && item.Amount <= 10)            
                item.Discount = 10;            
            else if (item.Amount > 10 && item.Amount <= 20)            
                item.Discount = 20;
            else
                item.Discount = 0;

            item.Status = Domain.Enums.ProductStatus.Active;

            item.TotalValue = (decimal)((float)item.UnitPrice - ((float)item.UnitPrice * ((float)item.Discount / 100))) * item.Amount;
        }       

        sale.TotalValue = (decimal)sale.Products.Where(x => x.Status == Domain.Enums.ProductStatus.Active)
                                               .GroupBy(item => item.SaleId)
                                               .Select(group => group.Sum(item => item.TotalValue)).FirstOrDefault();

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }
}
