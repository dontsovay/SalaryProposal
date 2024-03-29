﻿namespace SalaryProposal.API.Models.Request
{
    /// <summary></summary>
    public class LoginRequest
    {
        /// <summary>Gets or sets the name of the user.</summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}
