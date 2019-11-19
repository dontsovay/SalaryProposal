using SalaryProposal.Infrastructure.Dto;
using SalaryProposal.Models.Models;

namespace SalaryProposal.API.Models.Response
{
    /// <summary></summary>
    public class LoginResponse
    {
        /// <summary>Gets the access token.</summary>
        /// <value>The access token.</value>
        public AccessToken AccessToken { get; }

        /// <summary>Gets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; }

        /// <summary>Gets the user.</summary>
        /// <value>The user.</value>
        public object User { get; }

        /// <summary>Initializes a new instance of the <see cref="LoginResponse"/> class.</summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="user">The user.</param>
        public LoginResponse(AccessToken accessToken, string refreshToken, Users user)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            User = new { user.FirstName, user.LastName, role = user.Role.Name };
        }
    }
}
