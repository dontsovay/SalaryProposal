using System.Net;
using SalaryProposal.API.Serialization;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;

namespace SalaryProposal.API.Presenters
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IOutputPort{SalaryProposal.Infrastructure.Dto.UseCaseResponses.ExchangeRefreshTokenResponse}" />
    public sealed class ExchangeRefreshTokenPresenter : IOutputPort<ExchangeRefreshTokenResponse>
    {
        /// <summary>Gets the content result.</summary>
        /// <value>The content result.</value>
        public JsonContentResult ContentResult { get; }

        /// <summary>Initializes a new instance of the <see cref="ExchangeRefreshTokenPresenter"/> class.</summary>
        public ExchangeRefreshTokenPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        /// <summary>Handles the specified response.</summary>
        /// <param name="response">The response.</param>
        public void Handle(ExchangeRefreshTokenResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Response.ExchangeRefreshTokenResponse(response.AccessToken, response.RefreshToken)) : JsonSerializer.SerializeObject(response.Message);
        }
    }
}
