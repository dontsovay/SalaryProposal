using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.Infrastructure.Dto;
using SalaryProposal.Infrastructure.Dto.GatewayResponses;
using SalaryProposal.Infrastructure.Dto.Requests;
using SalaryProposal.Infrastructure.Dto.Responses;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Specifications;
using SalaryProposal.Models.Models;
using SalaryProposal.Models.Settings;

namespace SalaryProposal.API.Services
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.API.Services.Interfaces.IUsersService" />
    public class UsersService : IUsersService
    {
        /// <summary>The users repository</summary>
        private readonly IUserRepository _usersRepository;

        /// <summary>The users settings</summary>
        private readonly UsersSettings _usersSettings;

        /// <summary>The filter settings</summary>
        private readonly FilterSettings _filterSettings;

        /// <summary>Initializes a new instance of the <see cref="UsersService"/> class.</summary>
        /// <param name="usersRepository">The users repository.</param>
        /// <param name="usersSettings">The users settings.</param>
        /// <param name="filterSettings">The filter settings.</param>
        public UsersService(IUserRepository usersRepository,
            IOptions<UsersSettings> usersSettings,
            IOptions<FilterSettings> filterSettings)
        {
            _usersRepository = usersRepository;
            _usersSettings = usersSettings.Value;
            _filterSettings = filterSettings.Value;
        }

        /// <summary>Creates the specified user.</summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<UserResponse> Create(UserRequest user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Role))
                {
                    user.Role = _usersSettings.DefaultRoleName;
                }

                if (user.IsActive == null)
                {
                    user.IsActive = _usersSettings.DefaultIsActiveStatus;
                }

                var _user = await _usersRepository.Create(user);
                return new UserResponse(_user);
            }
            catch (Exception ex)
            {
                return new UserResponse(false, new[] { new Error("createError", ex.Message) });
            }
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<UserResponse> GetById(Guid id)
        {
            try
            {
                var user = await _usersRepository.GetById(id);
                return new UserResponse(user, true);
            }
            catch (Exception ex)
            {
                return new UserResponse(false, new[] { new Error("getByIdError", ex.Message) });
            }
        }

        /// <summary>Get List Users.</summary>
        /// <returns>Return List of Users</returns>
        public async Task<UsersResponse> GetList(FilterRequest filter = null)
        {
            try
            {
                if (filter != null)
                {
                    if (filter.Limit.HasValue && (filter.Limit.Value > _filterSettings.MaxLimitValue || filter.Limit.Value < 0))
                    {
                        throw new Exception($"Invalid limit value, valid range value: [0..{_filterSettings.MaxLimitValue}]");
                    } else
                    {
                        filter.Limit = _filterSettings.MaxLimitValue;
                    }
                }

                var listUsers = await _usersRepository.ListAll(filter);
                var allCount = await _usersRepository.Count();

                return new UsersResponse(allCount, listUsers, true);
            }
            catch (Exception ex)
            {
                return new UsersResponse(false, new[] { new Error("getListError", ex.Message) });
            }
        }

        /// <summary>Updates the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserResponse> Update(Guid id, UserRequest user)
        {
            try
            {
                await _usersRepository.Update(id, user);
                return await GetById(id);
            }
            catch (Exception ex)
            {
                return new UserResponse(false, new[] { new Error("updateError", ex.Message) });
            }
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<StatusResponse> Delete(Guid id)
        {
            try
            {
                await _usersRepository.Delete(id);
                return new StatusResponse(true);
            }
            catch (Exception ex)
            {
                return new StatusResponse(false, new[] { new Error("deleteError", ex.Message) });
            }
        }
    }
}
