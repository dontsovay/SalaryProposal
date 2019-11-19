using System.Threading.Tasks;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    /// <seealso cref="Roles" />
    public interface IRoleRepository : IRepository<Roles>
    {
        /// <summary>Finds the name of the by.</summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        Task<Roles> FindByName(string roleName);
    }
}