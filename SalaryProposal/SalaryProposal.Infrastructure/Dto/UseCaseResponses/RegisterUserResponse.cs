using System;
using System.Collections.Generic;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.Infrastructure.Dto.UseCaseResponses
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCaseResponseMessage" />
    public class RegisterUserResponse : UseCaseResponseMessage
    {
        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; }

        /// <summary>Gets the errors.</summary>
        /// <value>The errors.</value>
        public IEnumerable<string> Errors { get; }

        /// <summary>Initializes a new instance of the <see cref="RegisterUserResponse"/> class.</summary>
        /// <param name="errors">The errors.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        public RegisterUserResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        /// <summary>Initializes a new instance of the <see cref="RegisterUserResponse"/> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="message">The message.</param>
        public RegisterUserResponse(Guid id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
