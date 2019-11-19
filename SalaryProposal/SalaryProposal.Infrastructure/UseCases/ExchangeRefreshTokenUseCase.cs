using System.Linq;
using System.Threading.Tasks;
using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.Services;
using SalaryProposal.Infrastructure.Interfaces.UseCases;
using SalaryProposal.Infrastructure.Specifications;

namespace SalaryProposal.Infrastructure.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCases.IExchangeRefreshTokenUseCase" />
    public sealed class ExchangeRefreshTokenUseCase : IExchangeRefreshTokenUseCase
    {
        /// <summary>The JWT token validator</summary>
        private readonly IJwtTokenValidator _jwtTokenValidator;

        /// <summary>The user repository</summary>
        private readonly IUserRepository _userRepository;

        /// <summary>The JWT factory</summary>
        private readonly IJwtFactory _jwtFactory;

        /// <summary>The token factory</summary>
        private readonly ITokenFactory _tokenFactory;


        /// <summary>Initializes a new instance of the <see cref="ExchangeRefreshTokenUseCase"/> class.</summary>
        /// <param name="jwtTokenValidator">The JWT token validator.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="jwtFactory">The JWT factory.</param>
        /// <param name="tokenFactory">The token factory.</param>
        public ExchangeRefreshTokenUseCase(IJwtTokenValidator jwtTokenValidator, IUserRepository userRepository, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _jwtTokenValidator = jwtTokenValidator;
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
        }

        /// <summary>Handles the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="outputPort">The output port.</param>
        /// <returns></returns>
        public async Task<bool> Handle(ExchangeRefreshTokenRequest message, IOutputPort<ExchangeRefreshTokenResponse> outputPort)
        {
            var cp = _jwtTokenValidator.GetPrincipalFromToken(message.AccessToken, message.SigningKey);
            // invalid token/signing key was passed and we can't extract user claims
            if (cp != null)
            {
                var id = cp.Claims.First(c => c.Type == "id");
                var user = await _userRepository.GetSingleBySpec(new UserSpecification(id.Value));
                if (user != null && user.HasValidRefreshToken(message.RefreshToken))
                {
                    var jwtToken = await _jwtFactory.GenerateEncodedToken(user.IdentityId, user.Role.Name, user.UserName);
                    var refreshToken = _tokenFactory.GenerateToken();
                    user.RemoveRefreshToken(message.RefreshToken); // delete the token we've exchanged
                    user.AddRefreshToken(refreshToken, user.Id, ""); // add the new one
                    await _userRepository.Update(user.Id, user);
                    outputPort.Handle(new ExchangeRefreshTokenResponse(jwtToken, refreshToken, true));
                    return true;
                }
            }
            outputPort.Handle(new ExchangeRefreshTokenResponse(false, "Invalid token."));
            return false;
        }
    }
}
