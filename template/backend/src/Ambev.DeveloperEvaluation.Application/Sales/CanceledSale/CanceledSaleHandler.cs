using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CanceledSale;

public class CanceledSaleHandler : IRequestHandler<CanceledSaleCommand, CanceledSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CanceledSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;       
    }

    public async Task<CanceledSaleResult> Handle(CanceledSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CanceledSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleValid = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (saleValid == null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

        saleValid.Status = command.Status;        

        var UpdatedSale = await _saleRepository.UpdateAsync(saleValid, cancellationToken);
        var result = _mapper.Map<CanceledSaleResult>(UpdatedSale);

        return result;
    }
}
