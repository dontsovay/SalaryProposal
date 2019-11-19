 using System.Security.Claims;

namespace SalaryProposal.Infrastructure.Interfaces.Services
{
    /// <summary></summary>
    public interface IJwtTokenValidator
    {
        /// <summary>Gets the principal from token.</summary>
        /// <param name="token">The token.</param>
        /// <param name="signingKey">The signing key.</param>
        /// <returns></returns>
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
