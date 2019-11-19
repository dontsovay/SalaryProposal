using System.Net;
using SalaryProposal.API.Serialization;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.API.Presenters
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IOutputPort{SalaryProposal.Infrastructure.Dto.UseCaseResponses.LoginResponse}" />
    public sealed class LoginPresenter : IOutputPort<LoginResponse>
    {
        /// <summary>Gets the content result.</summary>
        /// <value>The content result.</value>
        public JsonContentResult ContentResult { get; }

        /// <summary>Initializes a new instance of the <see cref="LoginPresenter"/> class.</summary>
        public LoginPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        /// <summary>Handles the specified response.</summary>
        /// <param name="response">The response.</param>
        public void Handle(LoginResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Response.LoginResponse(response.AccessToken, response.RefreshToken, response.User)) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}
