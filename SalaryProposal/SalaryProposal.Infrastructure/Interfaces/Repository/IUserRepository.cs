using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SalaryProposal.Infrastructure.Dto.GatewayResponses.Repositories;
using SalaryProposal.Infrastructure.Dto.Requests;
using SalaryProposal.Infrastructure.Dto.Responses;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    /// <seealso cref="Users" />
    public interface IUserRepository : IRepository<Users>
    {
        /// <summary>Counts this instance.</summary>
        /// <returns></returns>
        Task<int> Count();

        /// <summary>Creates the specified user.</summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<Users> Create(UserRequest user);

        /// <summary>Gets all.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        Task<List<Users>> ListAll(FilterRequest filter = null);
        
        /// <summary>Updates the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task Update(Guid id, UserRequest user);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        new Task Delete(Guid id);

        /// <summary>Finds the name of the by.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<Users> FindByName(string userName);

        /// <summary>Finds the by email.</summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        Task<Users> FindByEmail(string email);

        /// <summary>Checks the password asynchronous.</summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<bool> CheckPasswordAsync(Users user, string password);

        /// <summary>Generates the password reset token.</summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<string> GeneratePasswordResetToken(Users user);

        /// <summary>Sends the email.</summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task SendEmail(string email, string subject, string message);

        /// <summary>Resets the password.</summary>
        /// <param name="user">The user.</param>
        /// <param name="token">The token.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        Task<IdentityResult> ResetPassword(Users user, string token, string newPassword);
    }
}