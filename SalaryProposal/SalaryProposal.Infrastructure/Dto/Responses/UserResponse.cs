using SalaryProposal.Infrastructure.Dto.GatewayResponses;
using SalaryProposal.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryProposal.Infrastructure.Dto.Responses
{
    /// <summary></summary>
    public class UserResponse : BaseGatewayResponse
    {
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets the identity identifier.</summary>
        /// <value>The identity identifier.</value>
        public Guid Id { get; private set; }
        /// <summary>Gets the name of the user.</summary>
        /// <value>The name of the user.</value>
        public string UserName { get; private set; } // Required by automapper

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; private set; }

        /// <summary>Gets or sets the role.</summary>
        /// <value>The role.</value>
        public string Role { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>Initializes a new instance of the <see cref="Users"/> class.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="identityId">The identity identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public UserResponse(
            string firstName,
            string lastName,
            Guid id,
            string userName,
            string email,
            string role,
            bool isActive = true,
            bool success = false,
            IEnumerable<Error> errors = null) : base(success, errors)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            UserName = userName;
            Email = email;
            Role = role;
            IsActive = isActive;
        }

        /// <summary>Initializes a new instance of the <see cref="UserResponse"/> class.</summary>
        /// <param name="user">The user.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="errors">The errors.</param>
        public UserResponse(Users user, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Role = user.Role?.ToString();
            IsActive = user.IsActive;
        }

        /// <summary>Initializes a new instance of the <see cref="UserResponse"/> class.</summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="errors">The errors.</param>
        public UserResponse(bool success = false, IEnumerable<Error> errors = null) : base(success, errors) { }
    }
}
