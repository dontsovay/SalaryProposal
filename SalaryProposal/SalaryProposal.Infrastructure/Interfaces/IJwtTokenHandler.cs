using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;


namespace SalaryProposal.Infrastructure.Interfaces
{
    /// <summary></summary>
    public interface IJwtTokenHandler
    {
        /// <summary>Writes the token.</summary>
        /// <param name="jwt">The JWT.</param>
        /// <returns></returns>
        string WriteToken(JwtSecurityToken jwt);

        /// <summary>Validates the token.</summary>
        /// <param name="token">The token.</param>
        /// <param name="tokenValidationParameters">The token validation parameters.</param>
        /// <returns></returns>
        ClaimsPrincipal ValidateToken(string token, TokenValidationParameters tokenValidationParameters);
    }
}
