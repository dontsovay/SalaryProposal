using System.Threading.Tasks;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary>Interface for Calculation Repository</summary>
    public interface ICalculationRepository
    {
        /// <summary>Gets the by position and region.</summary>
        /// <param name="position">The position.</param>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        Task<CalculationData> GetByPositionAndRegion(string position, string region);
    }
}