using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryProposal.Infrastructure.Dto;
using SalaryProposal.Infrastructure.Dto.UseCaseRequests;
using SalaryProposal.Infrastructure.Dto.UseCaseResponses;
using SalaryProposal.Infrastructure.Interfaces;
using SalaryProposal.Infrastructure.Interfaces.Services;
using SalaryProposal.Infrastructure.Interfaces.UseCases;

namespace SalaryProposal.Infrastructure.UseCases
{
    /// <summary></summary>
    /// <seealso cref="SalaryProposal.Infrastructure.Interfaces.UseCases.IForgotPasswordUseCase" />
    public sealed class ForgotPasswordUseCase : IForgotPasswordUseCase
    {
        /// <summary>The user repository</summary>
        private readonly IUserRepository _userRepository;

        /// <summary>The urlhelper</summary>
        private readonly IUrlHelper _urlhelper;

        /// <summary>Initializes a new instance of the <see cref="ForgotPasswordUseCase"/> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="urlhelper">The urlhelper.</param>
        public ForgotPasswordUseCase(IUserRepository userRepository, IUrlHelper urlhelper)
        {
            _userRepository = userRepository;
            _urlhelper = urlhelper;
        }

        /// <summary>Handles the specified message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="outputPort">The output port.</param>
        /// <returns></returns>
        public async Task<bool> Handle(ForgotPasswordRequest message, IOutputPort<ForgotPasswordResponse> outputPort)
        {
            if (!string.IsNullOrEmpty(message.Email))
            {
                // ensure we have a user with the given user name
                var user = await _userRepository.FindByEmail(message.Email);
                if (user != null)
                {
                    var code = await _userRepository.GeneratePasswordResetToken(user);
                    var callbackUrl = _urlhelper.Action("ResetPassword", "Auth", new
                    {
                        UserId = user.Id,
                        Code = System.Net.WebUtility.UrlEncode(code)
                    }, 
                    protocol: _urlhelper.ActionContext.HttpContext.Request.Scheme);
                    await _userRepository.SendEmail(user.Email, "Reset Password",
                        $"Please reset your password by clicking here: <a href=\"{callbackUrl}\">link</a>");
                    outputPort.Handle(new ForgotPasswordResponse(true));
                    return true;
                }
            }
            outputPort.Handle(new ForgotPasswordResponse(new[] { new Error("email_failure", "Invalid email.") }));
            return false;
        }
    }
}
