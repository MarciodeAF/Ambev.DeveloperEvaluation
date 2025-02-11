
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;       
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleValid = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (saleValid == null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

        var sale = _mapper.Map<Sale>(command);

        foreach (var item in sale.Products)
        {
            if (item.Status != Domain.Enums.ProductStatus.Active)
                continue;

            if (item.Amount > 4 && item.Amount < 10)
                item.Discount = 10;
            else if (item.Amount > 10 && item.Amount < 20)
                item.Discount = 20;
            else
                item.Discount = 0;

            item.TotalValue = (decimal)((float)item.UnitPrice - ((float)item.UnitPrice * ((float)item.Discount / 100))) * item.Amount;
        }

        sale.CreatedSale = saleValid.CreatedSale;
        sale.TotalValue = (decimal)sale.Products.Where(x => x.Status == Domain.Enums.ProductStatus.Active)
                                                .GroupBy(item => item.SaleId)
                                                .Select(group => group.Sum(item => ((float)item.UnitPrice - ((float)item.UnitPrice * ((float)item.Discount / 100))) * item.Amount )).FirstOrDefault();

        var UpdatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);
        var result = _mapper.Map<UpdateSaleResult>(UpdatedSale);

        return result;
    }
}
