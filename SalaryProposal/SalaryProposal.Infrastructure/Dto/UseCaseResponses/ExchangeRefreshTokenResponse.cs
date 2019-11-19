using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.Infrastructure.Dto.UseCaseResponses
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCaseResponseMessage" />
    public class ExchangeRefreshTokenResponse : UseCaseResponseMessage
    {
        /// <summary>Gets the access token.</summary>
        /// <value>The access token.</value>
        public AccessToken AccessToken { get; }

        /// <summary>Gets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; }

        /// <summary>Initializes a new instance of the <see cref="ExchangeRefreshTokenResponse"/> class.</summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        public ExchangeRefreshTokenResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ExchangeRefreshTokenResponse"/> class.</summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
