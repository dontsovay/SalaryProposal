using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaryProposal.Infrastructure.Context;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Repositories
{
    /// <summary></summary>
    /// <seealso cref="Roles" />
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IRoleRepository" />
    public class RoleRepository : BaseRepository<Roles>, IRoleRepository
    {
        /// <summary>Initializes a new instance of the <see cref="RoleRepository"/> class.</summary>
        /// <param name="context">The context.</param>
        public RoleRepository(DBContext context) : base(context) { }

        /// <summary>Finds the name of the by.</summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public async Task<Roles> FindByName(string roleName)
        {
            var findRole = roleName.ToLower();
            return await _context.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == findRole);
        }
    }
}
