using System;
using System.Security.Cryptography;
using SalaryProposal.Infrastructure.Interfaces.Services;

namespace SalaryProposal.Infrastructure.Auth
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.Services.ITokenFactory" />
    internal sealed class TokenFactory : ITokenFactory
    {
        /// <summary>Generates the token.</summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public string GenerateToken(int size = 32)
        {
            var randomNumber = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
