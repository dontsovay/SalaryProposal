using System.Threading.Tasks;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IRepository{SalaryProposal.Models.Models.Regions}" />
    public interface IRegionRepository : IRepository<Regions>
    {
        /// <summary>Finds the name of the by.</summary>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        Task<Regions> FindByName(string regionName);
    }
}