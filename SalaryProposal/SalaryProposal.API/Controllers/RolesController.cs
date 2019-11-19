using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.API.ViewModels;

namespace SalaryProposal.API.Controllers
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/roles")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Authorize(Policy = "ApiUser")]
    public class RolesController : Controller
    {
        /// <summary>The roles service</summary>
        private readonly IRolesService _rolesService;

        /// <summary>Initializes a new instance of the <see cref="RolesController"/> class.</summary>
        /// <param name="rolesService">The roles service.</param>
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        /// <summary>Gets this instance.</summary>
        /// <returns>Return list of roles</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolesViewModel>>> ListPositions()
        {
            return Ok(await _rolesService.GetList());
        }
    }
}