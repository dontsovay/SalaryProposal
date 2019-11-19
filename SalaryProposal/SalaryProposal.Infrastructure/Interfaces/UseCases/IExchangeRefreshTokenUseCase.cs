using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;

namespace SalaryProposal.Infrastructure.Interfaces.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequestHandler{SalaryProposal.Infrastructure.Dto.UseCaseRequests.ExchangeRefreshTokenRequest, SalaryProposal.Infrastructure.Dto.UseCaseResponses.ExchangeRefreshTokenResponse}" />
    public interface IExchangeRefreshTokenUseCase : IUseCaseRequestHandler<ExchangeRefreshTokenRequest, ExchangeRefreshTokenResponse> { }
}
