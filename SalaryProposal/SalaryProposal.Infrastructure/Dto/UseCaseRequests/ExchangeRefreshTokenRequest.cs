using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.Infrastructure.Dto.UseCaseRequests
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequest{SalaryProposal.Infrastructure.Dto.UseCaseResponses.ExchangeRefreshTokenResponse}" />
    public class ExchangeRefreshTokenRequest : IUseCaseRequest<ExchangeRefreshTokenResponse>
    {
        /// <summary>Gets the access token.</summary>
        /// <value>The access token.</value>
        public string AccessToken { get; }

        /// <summary>Gets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; }

        /// <summary>Gets the signing key.</summary>
        /// <value>The signing key.</value>
        public string SigningKey { get; }

        /// <summary>Initializes a new instance of the <see cref="ExchangeRefreshTokenRequest"/> class.</summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="signingKey">The signing key.</param>
        public ExchangeRefreshTokenRequest(string accessToken, string refreshToken, string signingKey)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            SigningKey = signingKey;
        }
    }
}
