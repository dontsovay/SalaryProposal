using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;
using System;

namespace SalaryProposal.Infrastructure.Dto.UseCaseRequests
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequest{SalaryProposal.Infrastructure.Dto.UseCaseResponses.ResetPasswordResponse}" />
    public class ResetPasswordRequest : IUseCaseRequest<ResetPasswordResponse> 
    {
        /// <summary>Gets or sets the user identifier.</summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; set; }

        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>Initializes a new instance of the <see cref="ResetPasswordRequest"/> class.</summary>
        public ResetPasswordRequest(Guid userId, string code)
        {
            UserId = userId;
            Code = code;
        }
    }
}