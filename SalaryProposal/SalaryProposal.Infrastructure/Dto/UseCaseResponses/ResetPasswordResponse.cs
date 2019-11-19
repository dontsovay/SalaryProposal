using System.Collections.Generic;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.Infrastructure.Dto.UseCaseResponses
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCaseResponseMessage" />
    public class ResetPasswordResponse : UseCaseResponseMessage
    {
        /// <summary>Gets the errors.</summary>
        /// <value>The errors.</value>
        public IEnumerable<Error> Errors { get; }

        /// <summary>Initializes a new instance of the <see cref="ResetPasswordResponse"/> class.</summary>
        /// <param name="errors">The errors.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        public ResetPasswordResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        /// <summary>Initializes a new instance of the <see cref="ResetPasswordResponse"/> class.</summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        public ResetPasswordResponse(bool success = false, string message = null) : base(success, message) { }
    }
}
