using NIHComicViewer.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHComicViewer.Application.Services.Interfaces
{
    /// <summary>
    /// Defines application-level operations for managing users.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface provide user-related functionality
    /// used by the application layer (for example, Razor Pages).
    /// </remarks>
    public interface IUserAppService
    {
        /// <summary>
        /// Determines whether the specified user has administrator privileges.
        /// </summary>
        /// <param name="userId">The identifier of the user to check. Cannot be <c>null</c> or empty.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result is <c>true</c> if the user is an administrator; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> IsUserAdminAsync(string userId);

        /// <summary>
        /// Retrieves the user corresponding to the specified identifier.
        /// </summary>
        /// <param name="userId">The identifier of the user to retrieve. Cannot be <c>null</c> or empty.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that returns the <see cref="UserModel"/> if found; otherwise, <c>null</c>.
        /// </returns>
        Task<UserModel?> GetUserAsync(string userId);

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <param name="userModel">The user model containing data for the new user. Must not be <c>null</c>.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result is <c>true</c> if the user was created successfully; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> CreateUserAsync(UserModel userModel);

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="userModel">The user model containing updated data. Must not be <c>null</c> and should reference an existing user.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result is <c>true</c> if the update succeeded; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> UpdateUserAsync(UserModel userModel);

        /// <summary>
        /// Deletes the user with the specified identifier.
        /// </summary>
        /// <param name="userId">The identifier of the user to delete. Cannot be <c>null</c> or empty.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result is <c>true</c> if the user was deleted; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> DeleteUserAsync(string userId);
        

    }
}
