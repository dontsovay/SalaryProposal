using System.Net;
using SalaryProposal.API.Serialization;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.API.Presenters
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IOutputPort{SalaryProposal.Infrastructure.Dto.UseCaseResponses.RegisterUserResponse}" />
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        /// <summary>Gets the content result.</summary>
        /// <value>The content result.</value>
        public JsonContentResult ContentResult { get; }

        /// <summary>Initializes a new instance of the <see cref="RegisterUserPresenter"/> class.</summary>
        public RegisterUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        /// <summary>Handles the specified response.</summary>
        /// <param name="response">The response.</param>
        public void Handle(RegisterUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
