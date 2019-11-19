using FluentValidation;
using SalaryProposal.API.Models.Request;

namespace SalaryProposal.API.Models.Validation
{
    /// <summary></summary>
    /// <seealso cref="FluentValidation.AbstractValidator{SalaryProposal.API.Models.Request.LoginRequest}" />
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        /// <summary>Initializes a new instance of the <see cref="LoginRequestValidator"/> class.</summary>
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
