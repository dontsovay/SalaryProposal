using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SalaryProposal.Infrastructure.Dto;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.Services;
using SalaryProposal.Models.Settings;

namespace SalaryProposal.Infrastructure.Auth
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.Services.IJwtFactory" />
    internal sealed class JwtFactory : IJwtFactory
    {
        /// <summary>The JWT token handler</summary>
        private readonly IJwtTokenHandler _jwtTokenHandler;

        /// <summary>The JWT options</summary>
        private readonly JwtIssuerOptions _jwtOptions;

        /// <summary>The JWT claim settings</summary>
        private readonly JwtClaimSettings _jwtClaimSettings;

        /// <summary>Initializes a new instance of the <see cref="JwtFactory"/> class.</summary>
        /// <param name="jwtTokenHandler">The JWT token handler.</param>
        /// <param name="jwtOptions">The JWT options.</param>
        internal JwtFactory(IJwtTokenHandler jwtTokenHandler, 
            IOptions<JwtIssuerOptions> jwtOptions,
            IOptions<JwtClaimSettings> jwtClaimSettings)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _jwtOptions = jwtOptions.Value;
            _jwtClaimSettings = jwtClaimSettings.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }

        /// <summary>Generates the encoded token.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public async Task<AccessToken> GenerateEncodedToken(string id, string role, string userName)
        {
            var identity = GenerateClaimsIdentity(id, role, userName);

            var claims = new[]
            {
                 new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
                 new Claim(JwtRegisteredClaimNames.Sub, userName),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                 identity.FindFirst(_jwtClaimSettings.jwtClaimIdentifiers.Rol),
                 identity.FindFirst(_jwtClaimSettings.jwtClaimIdentifiers.Id)
             };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                _jwtOptions.NotBefore,
                _jwtOptions.Expiration,
                _jwtOptions.SigningCredentials);

            return new AccessToken(_jwtTokenHandler.WriteToken(jwt), (int)_jwtOptions.ValidFor.TotalSeconds);
        }

        /// <summary>Generates the claims identity.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        private ClaimsIdentity GenerateClaimsIdentity(string id, string role, string userName)
        {
            var claims = new List<Claim>()
            {
                new Claim(_jwtClaimSettings.jwtClaimIdentifiers.Id, id),
                new Claim(_jwtClaimSettings.jwtClaimIdentifiers.Rol, _jwtClaimSettings.jwtClaims.ApiAccess)
            };
            if (!string.IsNullOrEmpty(role))
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role, ClaimValueTypes.String));
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), claims);
        }

        /// <summary></summary>
        /// <param name="date"></param>
        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        /// <summary>Throws if invalid options.</summary>
        /// <param name="options">The options.</param>
        /// <exception cref="ArgumentNullException">options
        /// or
        /// SigningCredentials
        /// or
        /// JtiGenerator</exception>
        /// <exception cref="ArgumentException">Must be a non-zero TimeSpan. - ValidFor</exception>
        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}
