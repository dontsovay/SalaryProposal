using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SalaryProposal.API.Models.Settings;
using SalaryProposal.API.Presenters;
using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Interfaces.UseCases;

namespace SalaryProposal.API.Controllers
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>The login use case</summary>
        private readonly ILoginUseCase _loginUseCase;

        /// <summary>The login presenter</summary>
        private readonly LoginPresenter _loginPresenter;

        /// <summary>The forgot password use case</summary>
        private readonly IForgotPasswordUseCase _forgotPasswordUseCase;

        /// <summary>The forgot password presenter</summary>
        private readonly ForgotPasswordPresenter _forgotPasswordPresenter;

        /// <summary>The reset password use case</summary>
        private readonly IResetPasswordUseCase _resetPasswordUseCase;

        /// <summary>The reset password presenter</summary>
        private readonly ResetPasswordPresenter _resetPasswordPresenter;

        /// <summary>The exchange refresh token use case</summary>
        private readonly IExchangeRefreshTokenUseCase _exchangeRefreshTokenUseCase;

        /// <summary>The exchange refresh token presenter</summary>
        private readonly ExchangeRefreshTokenPresenter _exchangeRefreshTokenPresenter;

        /// <summary>The authentication settings</summary>
        private readonly AuthSettings _authSettings;

        /// <summary>Initializes a new instance of the <see cref="AuthController"/> class.</summary>
        /// <param name="loginUseCase">The login use case.</param>
        /// <param name="loginPresenter">The login presenter.</param>
        /// <param name="forgotPasswordUseCase">The forgot password use case.</param>
        /// <param name="forgotPasswordPresenter">The forgot password presenter.</param>
        /// <param name="resetPasswordUseCase">The reset password use case.</param>
        /// <param name="resetPasswordPresenter">The reset password presenter.</param>
        /// <param name="exchangeRefreshTokenUseCase">The exchange refresh token use case.</param>
        /// <param name="exchangeRefreshTokenPresenter">The exchange refresh token presenter.</param>
        /// <param name="authSettings">The authentication settings.</param>
        public AuthController(
            ILoginUseCase loginUseCase,
            LoginPresenter loginPresenter,
            IForgotPasswordUseCase forgotPasswordUseCase,
            ForgotPasswordPresenter forgotPasswordPresenter,
            IResetPasswordUseCase resetPasswordUseCase,
            ResetPasswordPresenter resetPasswordPresenter,
            IExchangeRefreshTokenUseCase exchangeRefreshTokenUseCase,
            ExchangeRefreshTokenPresenter exchangeRefreshTokenPresenter,
            IOptions<AuthSettings> authSettings)
        {
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
            _forgotPasswordUseCase = forgotPasswordUseCase;
            _forgotPasswordPresenter = forgotPasswordPresenter;
            _resetPasswordUseCase = resetPasswordUseCase;
            _resetPasswordPresenter = resetPasswordPresenter;
            _exchangeRefreshTokenUseCase = exchangeRefreshTokenUseCase;
            _exchangeRefreshTokenPresenter = exchangeRefreshTokenPresenter;
            _authSettings = authSettings.Value;
        }

        // POST api/auth/login
        /// <summary>Logins the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Models.Request.LoginRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _loginUseCase.Handle(new LoginRequest(request.UserName, request.Password, Request.HttpContext.Connection.RemoteIpAddress?.ToString()), _loginPresenter);
            return _loginPresenter.ContentResult;
        }

        // GET api/auth/ResetPassword
        /// <summary>Resets the password.</summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpGet("ResetPassword")]
        public async Task<ActionResult> ResetPassword([FromQuery] Models.Request.ResetPassword request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _resetPasswordUseCase.Handle(new ResetPasswordRequest(request.UserId, request.Code), _resetPasswordPresenter);
            return _resetPasswordPresenter.ContentResult;
        }

        // POST api/auth/ForgotPassword
        /// <summary>Forgots the password.</summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword([FromBody] Models.Request.ForgotPassword request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _forgotPasswordUseCase.Handle(new ForgotPasswordRequest(request.Email), _forgotPasswordPresenter);
            return _forgotPasswordPresenter.ContentResult;
        }

        // POST api/auth/refreshtoken
        /// <summary>Refreshes the token.</summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("refreshtoken")]
        public async Task<ActionResult> RefreshToken([FromBody] Models.Request.ExchangeRefreshTokenRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _exchangeRefreshTokenUseCase.Handle(new ExchangeRefreshTokenRequest(request.AccessToken, request.RefreshToken, _authSettings.SecretKey), _exchangeRefreshTokenPresenter);
            return _exchangeRefreshTokenPresenter.ContentResult;
        }
    }
}
