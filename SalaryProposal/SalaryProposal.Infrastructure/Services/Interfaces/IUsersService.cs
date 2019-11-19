using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryProposal.Infrastructure.Dto.GatewayResponses;
using SalaryProposal.Infrastructure.Dto.Requests;
using SalaryProposal.Infrastructure.Dto.Responses;
using SalaryProposal.Models.Models;

namespace SalaryProposal.API.Services.Interfaces
{
    /// <summary>Interface for Users Service</summary>
    public interface IUsersService
    {
        /// <summary>Creates the specified user.</summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<UserResponse> Create(UserRequest user);

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<UserResponse> GetById(Guid id);

        /// <summary>Lists Users.</summary>
        /// <returns>Return List of Users</returns>
        Task<UsersResponse> GetList(FilterRequest filter = null);

        /// <summary>Updates the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<UserResponse> Update(Guid id, UserRequest user);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<StatusResponse> Delete(Guid id);
    }
}
