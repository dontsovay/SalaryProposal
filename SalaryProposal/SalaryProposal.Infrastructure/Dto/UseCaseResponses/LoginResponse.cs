using System.Collections.Generic;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Dto.UseCaseResponses
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCaseResponseMessage" />
    public class LoginResponse : UseCaseResponseMessage
    {
        /// <summary>Gets the access token.</summary>
        /// <value>The access token.</value>
        public AccessToken AccessToken { get; }

        /// <summary>Gets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; }

        /// <summary>Gets the user.</summary>
        /// <value>The user.</value>
        public Users User { get; }

        /// <summary>Gets the errors.</summary>
        /// <value>The errors.</value>
        public IEnumerable<Error> Errors { get; }

        /// <summary>Initializes a new instance of the <see cref="LoginResponse"/> class.</summary>
        /// <param name="errors">The errors.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        public LoginResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        /// <summary>Initializes a new instance of the <see cref="LoginResponse"/> class.</summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        public LoginResponse(AccessToken accessToken, string refreshToken, Users user, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            User = user;
        }
    }
}
