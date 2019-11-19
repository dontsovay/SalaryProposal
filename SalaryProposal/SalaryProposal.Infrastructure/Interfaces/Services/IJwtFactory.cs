using System.Threading.Tasks;
using SalaryProposal.Infrastructure.Dto;

namespace SalaryProposal.Infrastructure.Interfaces.Services
{
    /// <summary></summary>
    public interface IJwtFactory
    {
        /// <summary>Generates the encoded token.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<AccessToken> GenerateEncodedToken(string id, string role, string userName);
    }
}
