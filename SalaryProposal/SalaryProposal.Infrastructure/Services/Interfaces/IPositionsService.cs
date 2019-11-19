using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryProposal.Models.Models;

namespace SalaryProposal.API.Services.Interfaces
{
    /// <summary>Interface for Position Service</summary>
    public interface IPositionsService
    {
        /// <summary>Lists Positions.</summary>
        /// <returns>Return List of Positions</returns>
        Task<IEnumerable<Positions>> GetList();
    }
}
