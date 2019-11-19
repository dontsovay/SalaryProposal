using System.Net;
using SalaryProposal.API.Serialization;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.API.Presenters
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IOutputPort{SalaryProposal.Infrastructure.Dto.UseCaseResponses.ResetPasswordResponse}" />
    public sealed class ResetPasswordPresenter : IOutputPort<ResetPasswordResponse>
    {
        /// <summary>Gets the content result.</summary>
        /// <value>The content result.</value>
        public JsonContentResult ContentResult { get; }

        /// <summary>Initializes a new instance of the <see cref="ResetPasswordPresenter"/> class.</summary>
        public ResetPasswordPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        /// <summary>Handles the specified response.</summary>
        /// <param name="response">The response.</param>
        public void Handle(ResetPasswordResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Response.ResetPasswordResponse()) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
