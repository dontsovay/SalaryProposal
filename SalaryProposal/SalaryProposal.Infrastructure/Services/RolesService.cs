using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.API.Services
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.API.Services.Interfaces.IRolesService" />
    public class RolesService : IRolesService
    {
        /// <summary>The roles repository</summary>
        private readonly IRoleRepository _rolesRepository;

        /// <summary>Initializes a new instance of the <see cref="RolesService"/> class.</summary>
        /// <param name="rolesRepository">The roles repository.</param>
        public RolesService(IRoleRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        /// <summary>Get List Roles.</summary>
        /// <returns>Return List of Roles</returns>
        public async Task<IEnumerable<Roles>> GetList()
        {
            return await _rolesRepository.ListAll();
        }
    }
}
