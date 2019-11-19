using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;

namespace SalaryProposal.Infrastructure.Interfaces.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequestHandler{SalaryProposal.Infrastructure.Dto.UseCaseRequests.LoginRequest, SalaryProposal.Infrastructure.Dto.UseCaseResponses.LoginResponse}" />
    public interface ILoginUseCase : IUseCaseRequestHandler<LoginRequest, LoginResponse>
    {
    }
}
