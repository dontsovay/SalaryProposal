using System;
using System.Linq;
using System.Threading.Tasks;
using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.UseCases;

namespace SalaryProposal.Infrastructure.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCases.IRegisterUserUseCase" />
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        /// <summary>The user repository</summary>
        private readonly IUserRepository _userRepository;

        /// <summary>Initializes a new instance of the <see cref="RegisterUserUseCase"/> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>Handles the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="outputPort">The output port.</param>
        /// <returns></returns>
        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            try
            {
                var response = await _userRepository.Create(
                    new Dto.Requests.UserRequest(message.FirstName, message.LastName, message.UserName, message.Email, "user", true, message.Password));
                outputPort.Handle(new RegisterUserResponse(response.Id, true));
            }
            catch (Exception ex)
            {
                outputPort.Handle(new RegisterUserResponse(new string[] { ex.Message }));
                return false;
            }
            return true;
        }
    }
}
