using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SalaryProposal.Infrastructure.Context;
using SalaryProposal.Infrastructure.Dto;
using SalaryProposal.Infrastructure.Dto.GatewayResponses.Repositories;
using SalaryProposal.Infrastructure.Dto.Requests;
using SalaryProposal.Infrastructure.Dto.Responses;
using SalaryProposal.Infrastructure.Helpers;
using SalaryProposal.Infrastructure.Identity;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Specifications;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Repositories
{
    /// <summary></summary>
    /// <seealso cref="BaseRepository{T}" />
    /// <seealso cref="IUserRepository" />
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        /// <summary>The user manager</summary>
        private readonly UserManager<AppUser> _userManager;

        /// <summary>The mapper</summary>
        private readonly IMapper _mapper;

        /// <summary>The email sender</summary>
        private readonly IEmailSender _emailSender;

        /// <summary>The role repository</summary>
        private readonly IRoleRepository _roleRepository;

        /// <summary>Initializes a new instance of the <see cref="UserRepository"/> class.</summary>
        /// <param name="context">The context.</param>
        public UserRepository(
            UserManager<AppUser> userManager,
            IMapper mapper,
            IEmailSender emailSender,
            IRoleRepository roleRepository,
            DBContext context) : base(context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailSender = emailSender;
            _roleRepository = roleRepository;
        }

        /// <summary>Counts this instance.</summary>
        /// <returns></returns>
        public async Task<int> Count()
        {
            return await _context.Users.CountAsync();
        }

        /// <summary>Checks the password asynchronous.</summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<bool> CheckPasswordAsync(Users user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }

        /// <summary>Finds the by email.</summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<Users> FindByEmail(string email)
        {
            var appUser = await _userManager.FindByEmailAsync(email);
            return appUser == null ? null : _mapper.Map(appUser, await GetSingleBySpec(new UserSpecification(appUser.Id)));
        }

        /// <summary>Finds the name of the by.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Users> FindByName(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            return appUser == null ? null : _mapper.Map(appUser, await GetSingleBySpec(new UserSpecification(appUser.Id)));
        }

        /// <summary>Generates the password reset token.</summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<string> GeneratePasswordResetToken(Users user)
        {
            var appUser = _mapper.Map<AppUser>(user);
            return await _userManager.GeneratePasswordResetTokenAsync(appUser);
        }

        /// <summary>Resets the password.</summary>
        /// <param name="user">The user.</param>
        /// <param name="token">The token.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public async Task<IdentityResult> ResetPassword(Users user, string token, string newPassword)
        {
            var appUser = _mapper.Map<AppUser>(user);
            return await _userManager.ResetPasswordAsync(appUser, token, newPassword);
        }

        /// <summary>Sends the email.</summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        public async Task SendEmail(string email, string subject, string message)
        {
            await _emailSender.SendEmailAsync(email, subject, message);
        }

        /// <summary>Creates the specified user.</summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<Users> Create(UserRequest user)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(user.Email);
                if (!(addr.Address == user.Email))
                    throw new Exception();
            }
            catch
            {
                throw new Exception("Invalid email format.");
            }

            var appUser = new AppUser { Email = user.Email, UserName = user.UserName };
            var result = await _userManager.CreateAsync(appUser, user.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault()?.Description);
            }

            var role = await _roleRepository.FindByName(user.Role);
            if (role == null)
            {
                throw new Exception($"Role \"{user.Role}\" not found.");
            }

            result = await _userManager.AddToRoleAsync(appUser, role.ToString());
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault()?.Description);
            }

            var _user = new Users(user.FirstName, user.LastName, appUser.Id, appUser.UserName, role, user.IsActive.Value);

            try
            {
                _context.Users.Add(_user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Cant create user: {ex.Message}");
            }

            _user.Email = user.Email;
            _user.UserName = user.UserName;

            return _user;
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">User not found.</exception>
        public new async Task<Users> GetById(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
            if (user == null)
                throw new Exception("User not found.");

            var appUser = await _userManager.FindByIdAsync(user.IdentityId);

            user.Email = appUser.Email;
            user.Role = _context.Roles.FirstOrDefault(e => e.Id == user.RoleId);

            return user;
        }

        /// <summary>Gets all.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public async Task<List<Users>> ListAll(FilterRequest filter = null)
        {
            IQueryable<Users> users = _context.Users;

            if (!string.IsNullOrEmpty(filter.Sort))
            {
                if (filter.SortType == SortType.Asc)
                {
                    users = users.OrderBy(s => filter.Sort);
                }
                else
                {
                    users = users.OrderByDescending(s => filter.Sort);
                }
                //users = (filter.Sort.ToLower() == "firstname" ? users.OrderBy(s => s.FirstName)
                //    : filter.Sort.ToLower() == "lastname" ? users.OrderBy(s => s.LastName)
                //    : users.OrderBy(s => s.Id));
            }
            else
            {
                if (filter.SortType == SortType.Asc)
                {
                    users = users.OrderBy(s => s.Id);
                }
                else
                {
                    users = users.OrderByDescending(s => s.Id);
                }
            }

            if (filter.Offset.HasValue && filter.Offset.Value >= 0)
            {
                users = users.Skip(filter.Offset.Value);
            }

            if (filter.Limit.HasValue)
            {
                users = users.Take(filter.Limit.Value);
            }

            if (!string.IsNullOrEmpty(filter.GlobalLike))
            {
                users = users.Where(e =>
                    e.FirstName.Contains(filter.GlobalLike) ||
                    e.LastName.Contains(filter.GlobalLike) ||
                    e.UserName.Contains(filter.GlobalLike)
                );
            }

            var _users = users.ToList();

            for (var i = 0; i < _users.Count; i++)
            {
                var appUser = await _userManager.FindByIdAsync(_users[i].IdentityId);
                _users[i].Email = appUser.Email;
                _users[i].Role = _context.Roles.FirstOrDefault(e => e.Id == _users[i].RoleId);
            }

            return _users;
        }

        /// <summary>Updates the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task Update(Guid id, UserRequest user)
        {
            var _user = _context.Users.FirstOrDefault(e => e.Id == id);
            if (_user == null)
                throw new Exception("User not found.");

            _user.Role = _context.Roles.FirstOrDefault(e => e.Id == _user.RoleId);

            if (!string.IsNullOrEmpty(user.FirstName))
            {
                _user.FirstName = user.FirstName;
            }

            if (!string.IsNullOrEmpty(user.LastName))
            {
                _user.LastName = user.LastName;
            }

            var appUser = await _userManager.FindByIdAsync(_user.IdentityId);
            if (appUser != null)
            {
                if (!string.IsNullOrEmpty(user.Email))
                {
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(user.Email);
                        if (!(addr.Address == user.Email))
                            throw new Exception("Invalid email format.");

                        var result = await _userManager.SetEmailAsync(appUser, user.Email);
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.FirstOrDefault()?.Description);
                        }
                        else
                        {
                            _user.Email = user.Email;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Wrong email: {ex.Message}");
                    }
                }

                if (!string.IsNullOrEmpty(user.Role))
                {   
                    try
                    {
                        var role = await _roleRepository.FindByName(user.Role);

                        await _userManager.RemoveFromRoleAsync(appUser, _user.Role.ToString());

                        _user.Role = role ?? throw new Exception($"Role \"{user.Role}\" not found.");

                        var result = await _userManager.AddToRoleAsync(appUser, user.Role);
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.FirstOrDefault()?.Description);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Can't set role: {ex.Message}");
                    }
                }

                if (!string.IsNullOrEmpty(user.UserName))
                {
                    var result = await _userManager.SetUserNameAsync(appUser, user.UserName);
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.FirstOrDefault()?.Description);
                    }
                    else
                    {
                        _user.UserName = user.UserName;
                    }
                }

                if (!string.IsNullOrEmpty(user.Password))
                {
                    var result = await _userManager.RemovePasswordAsync(appUser);
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.FirstOrDefault()?.Description);
                    }

                    result = await _userManager.AddPasswordAsync(appUser, user.Password);
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.FirstOrDefault()?.Description);
                    }
                }
            }

            try
            {
                _context.Users.Update(_user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Can't update: {ex.Message}");
            }
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">User not found.
        /// or
        /// Cant remove user: {ex.Message}</exception>
        public new async Task Delete(Guid id)
        {
            var user = _context.Users.FirstOrDefault(e => e.Id == id);
            if (user == null)
                throw new Exception("User not found.");

            var _user = await _userManager.FindByIdAsync(user.IdentityId);
            var result = await _userManager.DeleteAsync(_user);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault()?.Description);
            }

            var tokens = _context.RefreshTokens.Where(e => e.UserId == id).ToList();
            try
            {
                _context.RefreshTokens.RemoveRange(tokens);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Cant remove user: {ex.Message}");
            }
        }
    }
}
