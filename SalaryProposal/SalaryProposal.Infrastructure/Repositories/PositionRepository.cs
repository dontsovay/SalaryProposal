using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaryProposal.Infrastructure.Context;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Repositories
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Repositories.BaseRepository{SalaryProposal.Models.Models.Positions}" />
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IPositionRepository" />
    public class PositionRepository : BaseRepository<Positions>, IPositionRepository
    {
        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="PositionRepository"/> class.
        /// </para>
        /// </summary>
        /// <param name="context">The context.</param>
        public PositionRepository(DBContext context) : base(context) { }

        /// <summary>Finds the name of the by.</summary>
        /// <param name="positionName">Name of the position.</param>
        /// <returns></returns>
        public async Task<Positions> FindByName(string positionName)
        {
            return await _context.Positions.FirstOrDefaultAsync(e => e.Name.Equals(positionName));
        }
    }
}
