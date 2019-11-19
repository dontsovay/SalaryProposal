using SalaryProposal.Infrastructure.Dto;

namespace SalaryProposal.API.Models.Response
{
    /// <summary></summary>
    public class ExchangeRefreshTokenResponse
    {
        /// <summary>Gets the access token.</summary>
        /// <value>The access token.</value>
        public AccessToken AccessToken { get; }

        /// <summary>Gets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; }

        /// <summary>Initializes a new instance of the <see cref="ExchangeRefreshTokenResponse"/> class.</summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
