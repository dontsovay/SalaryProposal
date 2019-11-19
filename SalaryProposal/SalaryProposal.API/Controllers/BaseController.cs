using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.API.ViewModels;

namespace SalaryProposal.API.Controllers
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseController : ControllerBase
    {
        /// <summary>Gets all.</summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult<IEnumerable<BaseViewModel>> GetAll()
        {
            return null;
        }

        /// <summary>Gets the view model by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual ActionResult<BaseViewModel> GetById(Guid id)
        {
            return null;
        }

        /// <summary>Creates the specified base view model.</summary>
        /// <param name="baseViewModel">The base view model.</param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult<BaseViewModel> Create([FromBody] BaseViewModel baseViewModel)
        {
            return null;
        }

        /// <summary>Updates the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="baseViewModel">The base view model.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual ActionResult<BaseViewModel> Update(Guid id, [FromBody] BaseViewModel baseViewModel)
        {
            return null;
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual ActionResult<BaseViewModel> Delete(Guid id)
        {
            return null;
        }
    }
}