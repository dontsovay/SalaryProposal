using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryProposal.Models.Models
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Models.Models.BaseModel" />
    public class Users : BaseModel
    {
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets the identity identifier.</summary>
        /// <value>The identity identifier.</value>
        public string IdentityId { get; private set; }
        /// <summary>Gets the name of the user.</summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; } // Required by automapper

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        public string PasswordHash { get; private set; }

        /// <summary>The refresh tokens</summary>
        private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();

        /// <summary>Gets the refresh tokens.</summary>
        /// <value>The refresh tokens.</value>
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

        /// <summary>Gets or sets the role identifier.</summary>
        /// <value>The role identifier.</value>
        public Guid RoleId { get; set; }

        /// <summary>Gets or sets the role.</summary>
        /// <value>The role.</value>
        public Roles Role { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive{ get; set; }

        /// <summary>Initializes a new instance of the <see cref="Users"/> class.</summary>
        internal Users() { /* Required by EF */ }

        /// <summary>Initializes a new instance of the <see cref="Users"/> class.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="identityId">The identity identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public Users(string firstName, string lastName, string identityId, string userName, Roles role, bool isActive = true)
        {
            FirstName = firstName;
            LastName = lastName;
            IdentityId = identityId;
            UserName = userName;
            Role = role;
            IsActive = isActive;
        }

        /// <summary>Determines whether [has valid refresh token] [the specified refresh token].</summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>
        ///   <c>true</c> if [has valid refresh token] [the specified refresh token]; otherwise, <c>false</c>.</returns>
        public bool HasValidRefreshToken(string refreshToken)
        {
            return _refreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
        }

        /// <summary>Adds the refresh token.</summary>
        /// <param name="token">The token.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="remoteIpAddress">The remote ip address.</param>
        /// <param name="daysToExpire">The days to expire.</param>
        public void AddRefreshToken(string token, Guid userId, string remoteIpAddress, double daysToExpire = 5)
        {
            _refreshTokens.Add(new RefreshToken(token, DateTime.UtcNow.AddDays(daysToExpire), userId, remoteIpAddress));
        }

        /// <summary>Removes the refresh token.</summary>
        /// <param name="refreshToken">The refresh token.</param>
        public void RemoveRefreshToken(string refreshToken)
        {
            _refreshTokens.Remove(_refreshTokens.First(t => t.Token == refreshToken));
        }
    }
}
