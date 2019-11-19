using FluentValidation;
using SalaryProposal.API.Models.Request;

namespace SalaryProposal.API.Models.Validation
{
    /// <summary></summary>
    /// <seealso cref="FluentValidation.AbstractValidator{SalaryProposal.API.Models.Request.RegisterUserRequest}" />
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        /// <summary>Initializes a new instance of the <see cref="RegisterUserRequestValidator"/> class.</summary>
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.UserName).Length(3, 255);
            RuleFor(x => x.Password).Length(6, 15);
        }
    }
}
