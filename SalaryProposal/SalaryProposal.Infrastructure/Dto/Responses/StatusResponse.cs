using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryProposal.Infrastructure.Dto.Responses
{
    /// <summary></summary>
    public class StatusResponse
    {
        /// <summary>Gets a value indicating whether this <see cref="BaseGatewayResponse"/> is success.</summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; }

        /// <summary>Gets the errors.</summary>
        /// <value>The errors.</value>
        public IEnumerable<Error> Errors { get; }

        /// <summary>Initializes a new instance of the <see cref="BaseGatewayResponse"/> class.</summary>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="errors">The errors.</param>
        public StatusResponse(bool success = false, IEnumerable<Error> errors = null)
        {
            Success = success;
            Errors = errors;
        }
    }
}
