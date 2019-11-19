using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.Infrastructure.Dto.UseCaseRequests
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequest{SalaryProposal.Infrastructure.Dto.UseCaseResponses.LoginResponse}" />
    public class LoginRequest : IUseCaseRequest<LoginResponse>
    {
        /// <summary>Gets the name of the user.</summary>
        /// <value>The name of the user.</value>
        public string UserName { get; }

        /// <summary>Gets the password.</summary>
        /// <value>The password.</value>
        public string Password { get; }

        /// <summary>Gets the remote ip address.</summary>
        /// <value>The remote ip address.</value>
        public string RemoteIpAddress { get; }

        /// <summary>Initializes a new instance of the <see cref="LoginRequest"/> class.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="remoteIpAddress">The remote ip address.</param>
        public LoginRequest(string userName, string password, string remoteIpAddress)
        {
            UserName = userName;
            Password = password;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
