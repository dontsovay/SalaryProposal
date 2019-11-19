using System.Net;
using SalaryProposal.API.Serialization;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.API.Presenters
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IOutputPort{SalaryProposal.Infrastructure.Dto.UseCaseResponses.ForgotPasswordResponse}" />
    public sealed class ForgotPasswordPresenter : IOutputPort<ForgotPasswordResponse>
    {
        /// <summary>Gets the content result.</summary>
        /// <value>The content result.</value>
        public JsonContentResult ContentResult { get; }

        /// <summary>Initializes a new instance of the <see cref="ForgotPasswordPresenter"/> class.</summary>
        public ForgotPasswordPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        /// <summary>Handles the specified response.</summary>
        /// <param name="response">The response.</param>
        public void Handle(ForgotPasswordResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Response.ForgotPasswordResponse()) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
