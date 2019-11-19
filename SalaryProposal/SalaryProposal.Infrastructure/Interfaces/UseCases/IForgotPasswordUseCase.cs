using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;

namespace SalaryProposal.Infrastructure.Interfaces.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequestHandler{SalaryProposal.Infrastructure.Dto.UseCaseRequests.ForgotPasswordRequest, SalaryProposal.Infrastructure.Dto.UseCaseResponses.ForgotPasswordResponse}" />
    public interface IForgotPasswordUseCase : IUseCaseRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse> { }
}
