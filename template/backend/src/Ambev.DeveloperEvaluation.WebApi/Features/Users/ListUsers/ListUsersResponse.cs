using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// API response model for UpdateUser operation
/// </summary>
public class ListUsersResponse
{
    //public class User()
    //{
    //    /// <summary>
    //    /// The unique identifier of the user
    //    /// </summary>
    //    public Guid Id { get; set; }

    //    /// <summary>
    //    /// The user's full name
    //    /// </summary>
    //    public string Username { get; set; } = string.Empty;

    //    /// <summary>
    //    /// The user's email address
    //    /// </summary>
    //    public string Email { get; set; } = string.Empty;

    //    /// <summary>
    //    /// The user's phone number
    //    /// </summary>
    //    public string Phone { get; set; } = string.Empty;

    //    /// <summary>
    //    /// The user's role in the system
    //    /// </summary>
    //    public UserRole Role { get; set; }

    //    /// <summary>
    //    /// The current status of the user
    //    /// </summary>
    //    public UserStatus Status { get; set; }

    //    /// <summary>
    //    /// Gets the date and time when the user was created.
    //    /// </summary>
    //    public DateTime CreatedAt { get; set; }

    //    /// <summary>
    //    /// Gets the date and time of the last update to the user's information.
    //    /// </summary>
    //    public DateTime? UpdatedAt { get; set; }
    //}


    public required IEnumerable<User> Users { get; set; }
}
