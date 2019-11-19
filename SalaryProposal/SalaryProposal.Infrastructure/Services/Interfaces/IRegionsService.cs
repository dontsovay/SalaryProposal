using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryProposal.Models.Models;

namespace SalaryProposal.API.Services.Interfaces
{
    /// <summary>Interface for Regions Service</summary>
    public interface IRegionsService
    {
        /// <summary>Lists Regions.</summary>
        /// <returns>Return List of Regions</returns>
        Task<IEnumerable<Regions>> GetList();
    }
}
