using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.API.ViewModels;

namespace SalaryProposal.API.Controllers
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/calculation")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Authorize(Policy = "ApiUser")]
    public class CalculationController : Controller
    {
        /// <summary>The calculation service</summary>
        private readonly ICalculationService _calculationService;

        /// <summary>Initializes a new instance of the <see cref="CalculationController"/> class.</summary>
        /// <param name="calculationService">The calculation service.</param>
        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        /// <summary>Calculates the specified calculation view model.</summary>
        /// <param name="calculationViewModel">The calculation view model.</param>
        /// <returns>Return min, max salary</returns>
        [HttpPost]
        public async Task<ActionResult<ReportViewModel>> Calculate([FromBody] CalculationViewModel calculationViewModel)
        {
            try
            {
                var result = await _calculationService.Calculate(calculationViewModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}