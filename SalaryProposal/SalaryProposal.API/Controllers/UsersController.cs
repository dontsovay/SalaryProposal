using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.API.ViewModels;
using SalaryProposal.Infrastructure.Dto.Requests;
using SalaryProposal.Infrastructure.Dto.Responses;

namespace SalaryProposal.API.Controllers
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.API.Controllers.BaseController" />
    [Route("api/users")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Authorize(Policy = "ApiUser")]
    public class UsersController : Controller
    {
        /// <summary>The users service</summary>
        private readonly IUsersService _usersService;

        /// <summary>Initializes a new instance of the <see cref="UsersController"/> class.</summary>
        /// <param name="usersService">The users service.</param>
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>Creates the specified user.</summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<ActionResult<UserResponse>> Create(UserRequest user)
        {
            return Ok(await _usersService.Create(user));
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User,Moderator")]
        public async Task<ActionResult<UserResponse>> GetById(Guid id)
        {
            return Ok(await _usersService.GetById(id));
        }

        /// <summary>Gets this instance.</summary>
        /// <returns>Return list of users</returns>
        [HttpGet]
        [Authorize(Roles = "Admin,User,Moderator")]
        public async Task<ActionResult<UsersResponse>> ListAll([FromQuery] FilterRequest filter = null)
        {
            return Ok(await _usersService.GetList(filter));
        }

        /// <summary>Updates the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<ActionResult<UserResponse>> Update(Guid id, UserRequest user)
        {
            return Ok(await _usersService.Update(id, user));
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<ActionResult<UserResponse>> Delete(Guid id)
        {   
            return Ok(await _usersService.Delete(id));
        }

    }
}