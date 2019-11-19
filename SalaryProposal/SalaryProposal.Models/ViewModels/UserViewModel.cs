using System;

namespace SalaryProposal.API.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the role fk.</summary>
        /// <value>The role fk.</value>
        public Guid RoleFk { get; set; }

        /// <summary>Gets or sets the role.</summary>
        /// <value>The role.</value>
        public string Role { get; set; }

        /// <summary>Gets or sets the status.</summary>
        /// <value>The status.</value>
        public string Status { get; set; }
    }
}