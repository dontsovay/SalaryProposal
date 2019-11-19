using System.Collections.Generic;
using System.Threading.Tasks;
using SalaryProposal.API.Services.Interfaces;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.API.Services
{
    /// <summary>Regions Service</summary>
    /// <seealso cref="SalaryProposal.API.Services.Interfaces.IRegionsService" />
    public class RegionsService : IRegionsService
    {
        /// <summary>The regions repository</summary>
        private readonly IRegionRepository _regionsRepository;

        /// <summary>Initializes a new instance of the <see cref="RegionsService"/> class.</summary>
        /// <param name="regionsRepository">The positions repository.</param>
        public RegionsService(IRegionRepository regionsRepository)
        {
            _regionsRepository = regionsRepository;
        }

        /// <summary>Get List Regions.</summary>
        /// <returns>Return List of Regions</returns>
        public async Task<IEnumerable<Regions>> GetList()
        {
            return await _regionsRepository.ListAll();
        }
    }
}
