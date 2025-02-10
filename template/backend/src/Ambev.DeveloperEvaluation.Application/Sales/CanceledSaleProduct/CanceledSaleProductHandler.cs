using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Sales.CanceledSaleProduct;

public class CanceledSaleProductHandler : IRequestHandler<CanceledSaleProductCommand, CanceledSaleProductResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CanceledSaleProductHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;       
    }

    public async Task<CanceledSaleProductResult> Handle(CanceledSaleProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CanceledSaleProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleValid = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);
        if (saleValid == null)
            throw new KeyNotFoundException($"Sale with ID {command.SaleId} not found");

        var product = saleValid.Products.Where(x => x.Id == command.Id).First();

        if (product == null)
            throw new KeyNotFoundException($"Product with ID {command.Id} not found");

        product.Status = command.Status;       

        var UpdatedSale = await _saleRepository.UpdateAsync(saleValid, cancellationToken);
        var result = _mapper.Map<CanceledSaleProductResult>(UpdatedSale);

        return result;
    }
}
