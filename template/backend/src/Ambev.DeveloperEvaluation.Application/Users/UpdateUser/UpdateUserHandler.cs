using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
///  Handler for processing UpdateUserHandler requests
/// </summary>
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateUserHandler
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="mapper"></param>
    public UpdateUserHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var userValid = await _userRepository.GetByIdAsync(command.Id, cancellationToken);
        if (userValid == null)
            throw new KeyNotFoundException($"User with ID {command.Id} not found");

        var user = _mapper.Map<User>(command);

        var updatedUser = await _userRepository.UpdateAsync(user, cancellationToken);
        var result = _mapper.Map<UpdateUserResult>(updatedUser);

        return result;
    }
}
