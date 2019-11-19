using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.Infrastructure.Dto.UseCaseRequests
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequest{SalaryProposal.Infrastructure.Dto.UseCaseResponses.ForgotPasswordResponse}" />
    public class ForgotPasswordRequest : IUseCaseRequest<ForgotPasswordResponse> 
    {
        /// <summary>Gets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; }

        /// <summary>Initializes a new instance of the <see cref="ForgotPasswordRequest"/> class.</summary>
        /// <param name="email">The email.</param>
        public ForgotPasswordRequest(string email)
        {
            Email = email;
        }
    }
}