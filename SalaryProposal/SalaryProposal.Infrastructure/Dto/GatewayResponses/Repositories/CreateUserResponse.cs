using System.Collections.Generic;

namespace SalaryProposal.Infrastructure.Dto.GatewayResponses.Repositories
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Dto.GatewayResponses.BaseGatewayResponse" />
    public sealed class CreateUserResponse : BaseGatewayResponse
    {
        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        public string Id { get; }

        /// <summary>Initializes a new instance of the <see cref="CreateUserResponse"/> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="errors">The errors.</param>
        public CreateUserResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
