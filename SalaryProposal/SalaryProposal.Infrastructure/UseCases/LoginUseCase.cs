using System.Threading.Tasks;
using SalaryProposal.Infrastructure.Dto;
using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.Services;
using SalaryProposal.Infrastructure.Interfaces.UseCases;

namespace SalaryProposal.Infrastructure.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCases.ILoginUseCase" />
    public sealed class LoginUseCase : ILoginUseCase
    {
        /// <summary>The user repository</summary>
        private readonly IUserRepository _userRepository;

        /// <summary>The JWT factory</summary>
        private readonly IJwtFactory _jwtFactory;

        /// <summary>The token factory</summary>
        private readonly ITokenFactory _tokenFactory;

        /// <summary>Initializes a new instance of the <see cref="LoginUseCase"/> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="jwtFactory">The JWT factory.</param>
        /// <param name="tokenFactory">The token factory.</param>
        public LoginUseCase(IUserRepository userRepository, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
        }

        /// <summary>Handles the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="outputPort">The output port.</param>
        /// <returns></returns>
        public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.UserName) && !string.IsNullOrEmpty(message.Password))
            {
                // ensure we have a user with the given user name
                var user = await _userRepository.FindByName(message.UserName);
                if (user != null)
                {
                    // validate password
                    if (await _userRepository.CheckPasswordAsync(user, message.Password))
                    {
                        // generate refresh token
                        var refreshToken = _tokenFactory.GenerateToken();
                        user.AddRefreshToken(refreshToken, user.Id, message.RemoteIpAddress);
                        await _userRepository.Update(user.Id, user);

                        // generate access token
                        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.IdentityId, user.Role.Name, user.UserName), refreshToken, user, true));
                        return true;
                    }
                }
            }
            outputPort.Handle(new LoginResponse(new[] { new Error("login_failure", "Invalid username or password.") }));
            return false;
        }
    }
}
