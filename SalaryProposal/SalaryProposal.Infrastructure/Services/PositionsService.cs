using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.API.Services
{
    /// <summary>Positions Service</summary>
    /// <seealso cref="SalaryProposal.API.Services.Interfaces.IPositionsService" />
    public class PositionsService : IPositionsService
    {
        /// <summary>The positions repository</summary>
        private readonly IPositionRepository _positionsRepository;

        /// <summary>Initializes a new instance of the <see cref="PositionsService"/> class.</summary>
        /// <param name="positionsRepository">The positions repository.</param>
        public PositionsService(IPositionRepository positionsRepository)
        {
            _positionsRepository = positionsRepository;
        }

        /// <summary>Get List Positions.</summary>
        /// <returns>Return List of Positions</returns>
        public async Task<IEnumerable<Positions>> GetList()
        {
            return await _positionsRepository.ListAll();
        }
    }
}
