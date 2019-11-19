using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.Infrastructure.Dto.UseCaseRequests
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequest{SalaryProposal.Infrastructure.Dto.UseCaseResponses.RegisterUserResponse}" />
    public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
    {
        /// <summary>Gets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; }

        /// <summary>Gets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; }

        /// <summary>Gets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; }

        /// <summary>Gets the name of the user.</summary>
        /// <value>The name of the user.</value>
        public string UserName { get; }

        /// <summary>Gets the password.</summary>
        /// <value>The password.</value>
        public string Password { get; }

        /// <summary>Initializes a new instance of the <see cref="RegisterUserRequest"/> class.</summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public RegisterUserRequest(string firstName, string lastName, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
