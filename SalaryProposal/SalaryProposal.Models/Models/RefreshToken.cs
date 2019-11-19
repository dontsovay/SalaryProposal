using System;

namespace SalaryProposal.Models.Models
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Models.Models.BaseModel" />
    public class RefreshToken : BaseModel
    {
        /// <summary>Gets the token.</summary>
        /// <value>The token.</value>
        public string Token { get; private set; }

        /// <summary>Gets the expires.</summary>
        /// <value>The expires.</value>
        public DateTime Expires { get; private set; }

        /// <summary>Gets the user identifier.</summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; private set; }

        /// <summary>Gets a value indicating whether this <see cref="RefreshToken"/> is active.</summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active => DateTime.UtcNow <= Expires;

        /// <summary>Gets the remote ip address.</summary>
        /// <value>The remote ip address.</value>
        public string RemoteIpAddress { get; private set; }

        /// <summary>Initializes a new instance of the <see cref="RefreshToken"/> class.</summary>
        /// <param name="token">The token.</param>
        /// <param name="expires">The expires.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="remoteIpAddress">The remote ip address.</param>
        public RefreshToken(string token, DateTime expires, Guid userId,string remoteIpAddress)
        {
            Token = token;
            Expires = expires;
            UserId = userId;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
