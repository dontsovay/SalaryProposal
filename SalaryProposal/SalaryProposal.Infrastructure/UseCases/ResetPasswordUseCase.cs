using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SalaryProposal.Infrastructure.Dto;
using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.Services;
using SalaryProposal.Infrastructure.Interfaces.UseCases;

namespace SalaryProposal.Infrastructure.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCases.IResetPasswordUseCase" />
    public sealed class ResetPasswordUseCase : IResetPasswordUseCase
    {
        /// <summary>The user repository</summary>
        private readonly IUserRepository _userRepository;

        /// <summary>Initializes a new instance of the <see cref="ResetPasswordUseCase"/> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        public ResetPasswordUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>Handles the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="outputPort">The output port.</param>
        /// <returns></returns>
        public async Task<bool> Handle(ResetPasswordRequest message, IOutputPort<ResetPasswordResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.Code))
            {
                var user = await _userRepository.GetById(message.UserId);
                if (user != null)
                {
                    var response = await _userRepository.ResetPassword(user, HttpUtility.UrlDecode(message.Code), Password.Generate(12, 1));
                    outputPort.Handle(response.Succeeded ? 
                        new ResetPasswordResponse(true) : 
                        new ResetPasswordResponse(response.Errors.Select(e => new Error(e.Code, e.Description))));
                    return response.Succeeded;
                }
            }
            outputPort.Handle(new ResetPasswordResponse(new[] { new Error("code_failure", "Invalid code.") }));
            return false;
        }
    }
}
