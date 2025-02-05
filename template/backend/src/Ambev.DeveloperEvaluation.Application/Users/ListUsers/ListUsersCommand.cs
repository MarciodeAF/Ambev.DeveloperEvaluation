using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

/// <summary>
/// Command for retrieving a users
/// </summary>
public class ListUsersCommand : IRequest<List<ListUsersResult>>
{
    public int Id { get; }
    /// <summary>
    /// Initializes a new instance 
    /// </summary>
    public ListUsersCommand(int id)
    {
        Id = id;
    }
}
