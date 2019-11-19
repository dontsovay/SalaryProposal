using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.Services;

namespace SalaryProposal.Infrastructure.Auth
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.Services.IJwtTokenValidator" />
    internal sealed class JwtTokenValidator : IJwtTokenValidator
    {
        /// <summary>The JWT token handler</summary>
        private readonly IJwtTokenHandler _jwtTokenHandler;

        /// <summary>Initializes a new instance of the <see cref="JwtTokenValidator"/> class.</summary>
        /// <param name="jwtTokenHandler">The JWT token handler.</param>
        internal JwtTokenValidator(IJwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        /// <summary>Gets the principal from token.</summary>
        /// <param name="token">The token.</param>
        /// <param name="signingKey">The signing key.</param>
        /// <returns></returns>
        public ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey)
        {
            return _jwtTokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
                ValidateLifetime = false // we check expired tokens here
            });
        }
    }
}
