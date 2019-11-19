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
    [Route("api/regions")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Authorize(Policy = "ApiUser")]
    public class RegionsController : Controller
    {
        /// <summary>The regions service</summary>
        private readonly IRegionsService _regionsService;

        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="RegionsController"/> class.
        /// </para>
        /// </summary>
        /// <param name="regionsService">The regions service.</param>
        public RegionsController(IRegionsService regionsService)
        {
            _regionsService = regionsService;
        }

        /// <summary>Gets the regions.</summary>
        /// <returns>Return list of regions</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionsViewModel>>> ListRegions()
        {
            return Ok(await _regionsService.GetList());
        }
    }
}