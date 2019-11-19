using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryProposal.Models.Models;

namespace SalaryProposal.API.Services.Interfaces
{
    /// <summary>Interface for Roles Service</summary>
    public interface IRolesService
    {
        /// <summary>Lists Roles.</summary>
        /// <returns>Return List of Roles</returns>
        Task<IEnumerable<Roles>> GetList();
    }
}
