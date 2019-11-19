using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;

namespace SalaryProposal.Infrastructure.Interfaces.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.IUseCaseRequestHandler{SalaryProposal.Infrastructure.Dto.UseCaseRequests.RegisterUserRequest, SalaryProposal.Infrastructure.Dto.UseCaseResponses.RegisterUserResponse}" />
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse> { }
}
