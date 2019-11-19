namespace SalaryProposal.API.Models.Request
{
    /// <summary></summary>
    public class ExchangeRefreshTokenRequest
    {
        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>Gets or sets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; set; }
    }
}

