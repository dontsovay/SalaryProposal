using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.API.ViewModels;

namespace SalaryProposal.API.Controllers
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.API.Controllers.BaseController" />
    [Route("api/positions")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Authorize(Policy = "ApiUser")]
    public class PositionsController : Controller
    {
        /// <summary>The positions service</summary>
        private readonly IPositionsService _positionsService;

        /// <summary>Initializes a new instance of the <see cref="PositionsController"/> class.</summary>
        /// <param name="positionsService">The positions service.</param>
        public PositionsController(IPositionsService positionsService)
        {
            _positionsService = positionsService;
        }

        /// <summary>Gets this instance.</summary>
        /// <returns>Return list of positions</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionsViewModel>>> ListPositions()
        {
            return Ok(await _positionsService.GetList());
        }
    }
}