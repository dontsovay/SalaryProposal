using System;

namespace SalaryProposal.API.Models.Request
{
    /// <summary></summary>
    public class ResetPassword
    {
        /// <summary>Gets or sets the user identifier.</summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; set; }

        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        public string Code { get; set; }
    }
}