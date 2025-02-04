using Ambev.DeveloperEvaluation.Application.Users.ListUsers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// Profile for mapping between Application and API ListUsers responses
/// </summary>
public class ListUsersProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListUsers feature
    /// </summary>
    public ListUsersProfile()
    {
        CreateMap<ListUsersResult, ListUsersResponse>(); 
    }
}
