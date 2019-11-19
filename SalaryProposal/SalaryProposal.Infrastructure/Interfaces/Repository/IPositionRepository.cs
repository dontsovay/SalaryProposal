using System.Threading.Tasks;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IRepository{SalaryProposal.Models.Models.Positions}" />
    public interface IPositionRepository : IRepository<Positions>
    {
        /// <summary>Finds the name of the by.</summary>
        /// <param name="positionName">Name of the position.</param>
        /// <returns></returns>
        Task<Positions> FindByName(string positionName);
    }
}