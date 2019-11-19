namespace SalaryProposal.Models.Settings
{
    /// <summary></summary>
    public class JwtClaimSettings
    {
        /// <summary></summary>
        public class JwtClaimIdentifiers
        {
            /// <summary>Gets or sets the rol.</summary>
            /// <value>The rol.</value>
            public string Rol { get; set; }

            /// <summary>Gets or sets the identifier.</summary>
            /// <value>The identifier.</value>
            public string Id { get; set; }
        }

        /// <summary></summary>
        public class JwtClaims
        {
            /// <summary>Gets or sets the API access.</summary>
            /// <value>The API access.</value>
            public string ApiAccess { get; set; }
        }

        /// <summary>Gets or sets the JWT claim identifiers.</summary>
        /// <value>The JWT claim identifiers.</value>
        public JwtClaimIdentifiers jwtClaimIdentifiers { get; set; }

        /// <summary>Gets or sets the JWT claims.</summary>
        /// <value>The JWT claims.</value>
        public JwtClaims jwtClaims { get; set; }
    }
}
