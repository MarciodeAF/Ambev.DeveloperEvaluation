using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListUsersHandler : IRequestHandler<ListUsersCommand, List<ListUsersResult>>
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
    public async Task<List<ListUsersResult>> Handle(ListUsersCommand command, CancellationToken cancellationToken)
    { 
        var user = await _userRepository.GetAll(cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"Users not found");       

        return _mapper.Map<List<ListUsersResult>>(user);
    }
}
