namespace SalaryProposal.Infrastructure.Dto
{
    /// <summary></summary>
    public sealed class AccessToken
    {
        /// <summary>Gets the token.</summary>
        /// <value>The token.</value>
        public string Token { get; }

        /// <summary>Gets the expires in.</summary>
        /// <value>The expires in.</value>
        public int ExpiresIn { get; }

        /// <summary>Initializes a new instance of the <see cref="AccessToken"/> class.</summary>
        /// <param name="token">The token.</param>
        /// <param name="expiresIn">The expires in.</param>
        public AccessToken(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
