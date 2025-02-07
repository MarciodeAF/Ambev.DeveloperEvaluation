
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.UserSale;

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

        var userValid = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (userValid == null)
            throw new KeyNotFoundException($"User with ID {command.Id} not found");

        var sale = _mapper.Map<Sale>(command);    

        var UpdatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);
        var result = _mapper.Map<UpdateSaleResult>(UpdatedSale);

        return result;
    }
}
