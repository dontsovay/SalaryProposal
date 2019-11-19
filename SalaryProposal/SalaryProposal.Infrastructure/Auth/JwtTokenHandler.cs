using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.Services;

namespace SalaryProposal.Infrastructure.Auth
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IJwtTokenHandler" />
    internal sealed class JwtTokenHandler : IJwtTokenHandler
    {
        /// <summary>The JWT security token handler</summary>
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        /// <summary>Initializes a new instance of the <see cref="JwtTokenHandler"/> class.</summary>
        internal JwtTokenHandler()
        {
            if (_jwtSecurityTokenHandler == null)
                _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        /// <summary>Writes the token.</summary>
        /// <param name="jwt">The JWT.</param>
        /// <returns></returns>
        public string WriteToken(JwtSecurityToken jwt)
        {
            return _jwtSecurityTokenHandler.WriteToken(jwt);
        }

        /// <summary>Validates the token.</summary>
        /// <param name="token">The token.</param>
        /// <param name="tokenValidationParameters">The token validation parameters.</param>
        /// <returns></returns>
        /// <exception cref="SecurityTokenException">Invalid token</exception>
        public ClaimsPrincipal ValidateToken(string token, TokenValidationParameters tokenValidationParameters)
        {
            try
            {
                var principal = _jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
