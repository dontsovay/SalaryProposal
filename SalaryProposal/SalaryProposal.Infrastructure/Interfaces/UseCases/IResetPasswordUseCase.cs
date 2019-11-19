using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;

namespace SalaryProposal.Infrastructure.Interfaces.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequestHandler{SalaryProposal.Infrastructure.Dto.UseCaseRequests.ResetPasswordRequest, SalaryProposal.Infrastructure.Dto.UseCaseResponses.ResetPasswordResponse}" />
    public interface IResetPasswordUseCase : IUseCaseRequestHandler<ResetPasswordRequest, ResetPasswordResponse> { }
}
