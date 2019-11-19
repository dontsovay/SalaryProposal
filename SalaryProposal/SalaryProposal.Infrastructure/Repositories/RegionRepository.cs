using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaryProposal.Infrastructure.Context;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Repositories
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Repositories.BaseRepository{SalaryProposal.Models.Models.Regions}" />
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IRegionRepository" />
    public class RegionRepository: BaseRepository<Regions>, IRegionRepository
    {
        /// <summary>Initializes a new instance of the <see cref="RegionRepository"/> class.</summary>
        /// <param name="context">The context.</param>
        public RegionRepository(DBContext context) : base(context) { }

        /// <summary>Finds the name of the by.</summary>
        /// <param name="regionName">Name of the region.</param>
        /// <returns></returns>
        public async Task<Regions> FindByName(string regionName)
        {
            return await _context.Regions.FirstOrDefaultAsync(e => e.Name.Equals(regionName));
        }
    }
}