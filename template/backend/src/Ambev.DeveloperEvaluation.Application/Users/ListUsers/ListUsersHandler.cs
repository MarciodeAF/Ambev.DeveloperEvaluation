using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using System.Collections;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;


/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListUsersHandler : IRequestHandler<ListUsersCommand, ListUsersResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUserCommand</param>
    public ListUsersHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetUserCommand request
    /// </summary>    
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<ListUsersResult> Handle(ListUsersCommand command, CancellationToken cancellationToken)
    { 
        var user = await _userRepository.GetAll(cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"Users not found");


        ListUsersResult t = _mapper.Map<ListUsersResult>(user);

        return _mapper.Map<ListUsersResult>(user);
  }
}
