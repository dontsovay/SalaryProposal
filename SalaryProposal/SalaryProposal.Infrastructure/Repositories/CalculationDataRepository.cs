using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaryProposal.Infrastructure.Context;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Repositories
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Repositories.BaseRepository{SalaryProposal.Models.Models.CalculationData}" />
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.ICalculationRepository" />
    public class CalculationDataRepository : BaseRepository<CalculationData>, ICalculationRepository
    {
        /// <summary>Initializes a new instance of the <see cref="CalculationDataRepository"/> class.</summary>
        /// <param name="context">The context.</param>
        public CalculationDataRepository(DBContext context) : base(context) { }

        /// <summary>Gets the by position and region.</summary>
        /// <param name="position">The position.</param>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<CalculationData> GetByPositionAndRegion(string position, string region)
        {
            return await _context.CalculationDatas
                .Include(i => i.Position)
                .Include(i => i.Region)
                .FirstOrDefaultAsync(e => e.Position.Name.Equals(position) && e.Region.Name.Equals(region));
        }
    }
}
